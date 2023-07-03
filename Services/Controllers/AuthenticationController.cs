using Library.Models.Security;
using Library.Models.Users;
using Library.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] UserRegister userCreate)
        {
            var result = await BusinessContext.Authentication!.Register(userCreate);
            return Ok(result);
        }

        [HttpPost("send-email/{email}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> SendEmail([FromRoute] string email)
        {
            UserRead user = BusinessContext.Users!.GetByEmail(email);
            if (user == null)
            {
                return BadRequest("User does not exist");
            }
            string newPasswordUrl = $"http://localhost:3000/renewPassword/email={email}";
            string body = "<p>Click on the link below to change your password!</p>" +
                $"<a href='{newPasswordUrl}'>Click here</a>";
            var message = new Message(new string[] { email },
                "Change Password",
                body,
                null);
            try
            {
                await BusinessContext.EmailSender.SendEmailAsync(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
            return Ok(message.ToString());
        }

        [HttpGet]
        [Route("decoded/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetUserDecodedPasswordByEmail([FromRoute] string email)
        {
            var decodedPassword = await BusinessContext.Authentication!.GetUserDecodedPasswordByEmail(email);
            return decodedPassword;
        }

        [HttpPut("renew-password")]
        public IActionResult RenewPassword([FromBody] RenewPasswordRequest request)
        {
            UserRead userToUpdate = BusinessContext.Users!.GetByEmail(request.Email);
            if (userToUpdate == null)
            {
                return BadRequest("User does not exist");
            }
            BusinessContext.Authentication!.UpdatePassword(userToUpdate, request.Password);
            return Ok(userToUpdate);
        }

        [HttpPost]
        [Route("register-admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegister userCreate)
        {
            var result = await BusinessContext.Authentication!.RegisterAdmin(userCreate);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            Tuple<JwtSecurityToken, string> result = await BusinessContext.Authentication!.Login(user);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(result.Item1),
                RefreshToken = result.Item2,
                Expiration = result.Item1.ValidTo
            });
        }

        [HttpPost]
        [Route("refresh-token")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            Tuple<JwtSecurityToken, string> result = await BusinessContext.Authentication!.RefreshToken(tokenModel);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(result.Item1),
                RefreshToken = result.Item2,
            });
        }

        [HttpPost]
        [Route("revoke/{username}")]
        public async Task<IActionResult> Revoke([FromRoute] string username)
        {
            bool result = await BusinessContext.Authentication!.Revoke(username);

            return Ok(result);
        }

        [HttpGet]
        [Route("loggedInUser")]
        [Authorize]
        public async Task<IActionResult> GetLoggedInUser()
        {
            var userRead = await BusinessContext.Authentication!.GetLoggedInUser();
            return Ok(userRead);
        }

        [HttpPost]
        [Route("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            bool result = await BusinessContext.Authentication!.RevokeAll();
            return Ok(result);
        }

        [HttpPost("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            var result = await BusinessContext.Authentication!.Logout();
            return Ok(result);
        }
    }
}