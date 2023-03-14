using BLL.Converters.Role;
using BLL.Converters.User;
using BLL.Core;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Library.Enums;
using Library.Models.Security;
using Library.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Implementation
{
    public class AuthenticationBL : BusinessObject, IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticationBL(IDALContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor
            ) : base(dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserRegister> RegisterAdmin(UserRegister model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return null;

            Guid newUserGuid = Guid.NewGuid();
            ApplicationUser user = new()
            {
                Id = newUserGuid.ToString(),
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return null;

            if (await _roleManager.RoleExistsAsync(Roles.Administrator.ToString()))
            {
                await _userManager.AddToRoleAsync(user, Roles.Administrator.ToString());
            }
            return model;
        }

        public async Task<UserRegister> Register(UserRegister model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return null;
            Guid newUserGuid = Guid.NewGuid();
            ApplicationUser user = new()
            {
                Id = newUserGuid.ToString(),
                Password = model.Password,
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                SurveyUserAnswers = new List<SurveyUserAnswer>()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (await _roleManager.RoleExistsAsync(UserRoles.Member))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Member);
            }
            if (!result.Succeeded)
            {
                return null;
            }
            return model;
        }

        public async Task<Tuple<JwtSecurityToken, string>> Login(UserLogin model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var result = await _userManager.GetRolesAsync(user);
                string role = result[0];
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, role)
                };
                JwtSecurityToken token = CreateToken(authClaims);
                if (!model.RememberMe)
                {
                    return Tuple.Create(token, "");
                }

                string refreshToken = GenerateRefreshToken();
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                var result2 = await _userManager.UpdateAsync(user);
                if (!result2.Succeeded)
                {
                    return null;
                }
                return Tuple.Create(token, refreshToken);
            }
            return null;
        }

        public async Task<Tuple<JwtSecurityToken, string>> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel is null)
            {
                return null;
            }

            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                return null;
            }

            string email = principal.Identity.Name;

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return null;
            }
            return Tuple.Create(newAccessToken, newRefreshToken);
        }

        public async Task<bool> Revoke(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            user.RefreshToken = null;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }
        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<UserRead> GetLoggedInUser()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Email);
            var userEntity = _dalContext.Users.GetByEmail(email!);
            var roles = await _userManager.GetRolesAsync(userEntity!);
            var userModel = UserReadConverter.ToBLLModel(userEntity!);
            userModel.Roles = RoleConverter.ToBLLModel(roles[0]);
            userModel.RefreshToken = "";
            return userModel;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}