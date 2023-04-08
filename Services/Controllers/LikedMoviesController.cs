using Library.Models.LikedMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Services.Controllers
{
    public class LikedMoviesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LikedMovieRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.LikedMovies!.GetAll());
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LikedMovieRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<LikedMovieRead>))]
        [Authorize]
        public IActionResult GetAllByLoggedUser()
        {
            var email = BusinessContext.HttpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            Guid? loggedInUserUid = BusinessContext.Users?.GetByEmail(email!).Uid;
            if (loggedInUserUid == null)
            {
                return null;
            }
            List<LikedMovieRead> likedMovies = BusinessContext.LikedMovies!.GetAllByLoggedUser(loggedInUserUid.ToString());
            if (likedMovies == null)
            {
                return NotFound();
            }
            return Ok(likedMovies);
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LikedMovieRead))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            return Ok(BusinessContext.LikedMovies!.GetByUid(uid));
        }


        [HttpGet("movie/user/{movieUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LikedMovieRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<LikedMovieRead>))]
        [Authorize]
        public IActionResult GetByUserAndMovie([FromRoute] Guid movieUid)
        {
            var email = BusinessContext.HttpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            Guid? loggedInUserUid = BusinessContext.Users?.GetByEmail(email!).Uid;
            if (loggedInUserUid == null)
            {
                return null;
            }
            LikedMovieRead likedMovie = BusinessContext.LikedMovies!.GetByUserAndMovie(movieUid, loggedInUserUid.ToString());
            if (likedMovie == null)
            {
                return NotFound();
            }
            return Ok(likedMovie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LikedMovieCreate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] LikedMovieCreate likedMovieCreate)
        {
            LikedMovieCreate likedMovie = BusinessContext.LikedMovies!.Add(likedMovieCreate);
            if (likedMovie == null)
            {
                return BadRequest();
            }
            return Ok(likedMovie);
        }

        [HttpDelete("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] Guid uid)
        {
            BusinessContext.LikedMovies!.Delete(uid);
            return Ok();
        }
    }
}