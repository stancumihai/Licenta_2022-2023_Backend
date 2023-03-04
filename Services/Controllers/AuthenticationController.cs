using BLL.Interfaces.Mechanisms;
using Library.Enums;
using Library.Models.Security;
using Library.Models.Users;
using Library.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        private IEmailSender _emailSender;

        public AuthenticationController(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        [HttpGet("loggedUser")]
        public ActionResult<UserToken> GetLoggedInUser()
        {
            var user = BusinessContext.Users.GetLoggedInUser();
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserLogin>> Register(UserLogin request)
        {
            if (BusinessContext.Users.GetByEmail(request.Email) != null)
            {
                return BadRequest(new HttpResponseException((int)HttpStatusCode.BadRequest, "User already exists"));
            }
            UserCreate user = new()
            {
                Email = request.Email,
                Password = request.Password
            };
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            BusinessContext.Users.Add(user);
            return Ok(request);
        }

        [HttpPut("renew-password")]
        public async Task<ActionResult<UserRead>> RenewPassword([FromBody] RenewPasswordPasswordRequest request)
        {
            UserRead user = BusinessContext.Users.GetByEmail(request.Email);
            if (user == null)
            {
                return BadRequest(new HttpResponseException((int)HttpStatusCode.BadRequest, "User does not exist"));
            }
            UserRead userToUpdate = user;
            userToUpdate.Password = request.Password;
            BusinessContext.Users.Update(userToUpdate);
            return Ok(userToUpdate);
        }

        [HttpPost("send-email/{email}")]
        public async Task<ActionResult<string>> SendEmail([FromRoute] string email)
        {
            UserRead user = BusinessContext.Users.GetByEmail(email);
            if (user == null)
            {
                return BadRequest(new HttpResponseException((int)HttpStatusCode.BadRequest, "User does not exist"));
            }
            string newPasswordUrl = $"http://localhost:3000/renewPassword/email={email}";
            string body = "<p>Change Password</p><br>" +
                "<p>Click on the link below</p>" +
                $"<a href='{newPasswordUrl}'>Click here</a>";
            var message = new Message(new string[] { email },
                "Change Password",
                body,
                null);
            try
            {
                await _emailSender.SendEmailAsync(message);
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseException((int)HttpStatusCode.BadRequest, e.Message));

            }
            return Ok(message.ToString());
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLogin request)
        {
            UserRead user = BusinessContext.Users.GetByEmail(request.Email);
            if (user == null)
            {
                return BadRequest(new HttpResponseException((int)HttpStatusCode.BadRequest, "User does not exist"));
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest(new HttpResponseException((int)HttpStatusCode.BadRequest, "Incorect Password"));
            }

            string token = CreateToken(user);
            Response.Cookies.Delete("jwtToken");
            var expireValue = DateTime.Now.AddMinutes(20);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Expires = expireValue,
            };
            Response.Cookies.Append("jwtToken", token, cookieOptions);
            if (!request.RememberMe)
            {
                user.TokenCreated = DateTime.Now;
                user.TokenExpires = expireValue;
                user.RefreshToken = "";
                BusinessContext.Users.Update(user);
                return Ok(token);
            }
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(user, refreshToken);
            return Ok(token);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<string>> Logout()
        {
            Response.Cookies.Delete("jwtToken");
            Response.Cookies.Delete("refreshToken");
            return Ok("User logged out");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            UserRead user = BusinessContext.Users.GetByRefreshToken(refreshToken);
            if (user == null)
            {
                return Unauthorized("User Not Authorized");
            }
            if (!user.RefreshToken.Equals(refreshToken))
            {

                return Unauthorized("Invalid Refresh Token.");
            }
            if (user.TokenExpires < DateTime.Now)
            {
                Response.Cookies.Delete("refreshToken");
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            Response.Cookies.Delete("jwtToken");
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(20),
            };
            Response.Cookies.Append("jwtToken", token, cookieOptions);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(user, newRefreshToken);
            return Ok(token);
        }

        private static RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }
        private void SetRefreshToken(UserRead user, RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
            BusinessContext.Users.Update(user);
        }

        private static string CreateToken(UserRead user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, Roles.Member.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}