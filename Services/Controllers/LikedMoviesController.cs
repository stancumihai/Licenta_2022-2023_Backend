using Library.Models.LikedMovie;
using Library.Models.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            List<LikedMovieRead> likedMovies = BusinessContext.LikedMovies!.GetAllByLoggedUser();
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LikedMovieRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public IActionResult GetByUserAndMovie([FromRoute] Guid movieUid)
        {
            LikedMovieRead likedMovie = BusinessContext.LikedMovies!.GetByUserAndMovie(movieUid);
            if (likedMovie == null)
            {
                return NotFound();
            }
            return Ok(likedMovie);
        }

        [HttpGet("user/{userUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetByAllByUser([FromRoute] string userUid)
        {
             List<MovieRead> likedMovies = BusinessContext.LikedMovies!.GetAllByUser(userUid);
            if (likedMovies == null)
            {
                return NotFound();
            }
            return Ok(likedMovies);
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