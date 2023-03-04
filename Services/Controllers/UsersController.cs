using Library.Models.Users;
using Microsoft.AspNetCore.Authorization;
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
            return Ok(BusinessContext.Users.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add([FromBody] UserCreate user)
        {
            return new ObjectResult(BusinessContext.Users.Add(user)) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserRead))]
        public IActionResult Update([FromBody] UserRead user)
        {
            UserRead? oldUser = BusinessContext.Users.GetByUid(user.Uid);
            if (oldUser == null)
            {
                return NotFound();
            }
            BusinessContext.Users.Update(user);
            return Ok(user);
        }

        [HttpDelete("{uid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromRoute] Guid uid)
        {
            UserRead? user = BusinessContext.Users.GetByUid(uid);
            if (user == null)
            {
                return NotFound();
            }
            BusinessContext.Users.Delete(uid);
            return NoContent();
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserRead))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            UserRead? user = BusinessContext.Users.GetByUid(uid);
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
            UserRead? user = BusinessContext.Users.GetByEmail(email);
            if (user == null)
            {
                var response = new HttpResponseException((int)HttpStatusCode.NotFound, "User Not Found");
                return BadRequest(response);
            }
            return Ok(user);
        }
        [HttpDelete("all")]
        public IActionResult DeleteAllUsers()
        {
            BusinessContext.Users.DeleteAll();
            return Ok("All users deleted");
        }
    }
}