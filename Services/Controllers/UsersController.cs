using Library.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using System.Net;

namespace Services.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.Users!.GetAll());
        }
        
        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserRead))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            UserRead? user = BusinessContext.Users!.GetByUid(uid);
            if (user == null)
            {
                var response = new HttpResponseException((int)HttpStatusCode.NotFound, "User Not Found");
                return BadRequest(response);
            }
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserRead))]
        public IActionResult GetByEmail([FromRoute] string email)
        {
            UserRead? user = BusinessContext.Users!.GetByEmail(email);
            if (user == null)
            {
                var response = new HttpResponseException((int)HttpStatusCode.NotFound, "User Not Found");
                return BadRequest(response);
            }
            return Ok(user);
        }
    }
}