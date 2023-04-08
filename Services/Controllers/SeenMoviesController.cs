using Library.Models.SeenMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Services.Controllers
{
    public class SeenMoviesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SeenMovieRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.SeenMovies!.GetAll());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeenMovieRead))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            return Ok(BusinessContext.SeenMovies!.GetByUid(uid));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SeenMovieCreate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] SeenMovieCreate seenMovieCreate)
        {
            SeenMovieCreate seenMovie = BusinessContext.SeenMovies!.Add(seenMovieCreate);
            if (seenMovie == null)
            {
                return BadRequest();
            }
            return Ok(seenMovie);
        }

        [HttpDelete("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] Guid uid)
        {
            BusinessContext.SeenMovies!.Delete(uid);
            return Ok();
        }

        [HttpGet("movie/user/{movieUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SeenMovieRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public IActionResult GetByUserAndMovie([FromRoute] Guid movieUid)
        {
            var email = BusinessContext.HttpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            Guid? loggedInUserUid = BusinessContext.Users?.GetByEmail(email!).Uid;
            if (loggedInUserUid == null)
            {
                return null;
            }
            SeenMovieRead seenMovie = BusinessContext.SeenMovies!.GetByUserAndMovie(movieUid, loggedInUserUid.ToString());
            if (seenMovie == null)
            {
                return NotFound();
            }
            return Ok(seenMovie);
        }
    }
}