using Library.Models;
using Library.Models.Movie;
using Library.Models.SeenMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SeenMovieRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public IActionResult GetByUserAndMovie([FromRoute] Guid movieUid)
        {
            List<SeenMovieRead> seenMovie = BusinessContext.SeenMovies!.GetByUserAndMovie(movieUid);
            if (seenMovie == null)
            {
                return NotFound();
            }
            return Ok(seenMovie);
        }

        [HttpGet("user/{userUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SeenMovieRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public IActionResult GetAllByUser([FromRoute] string userUid)
        {
            List<MovieRead>? seenMovies = BusinessContext.SeenMovies.GetAllByUser(userUid);
            if (seenMovies == null)
            {
                return NotFound();
            }
            return Ok(seenMovies);
        }

        [HttpGet("user/monthlyMovies")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SeenMovieRead>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public List<MonthlyAppUsageModel> GetMonthlySeenMoviesByUser()
        {
            return BusinessContext.SeenMovies.GetMonthlySeenMoviesByUser();
        }

        [HttpGet("user/topSeenGenres")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDictionary<string, int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public List<TopGenreModel> GetTopSeenGenresByUser()
        {
            return BusinessContext.SeenMovies.GetTopSeenGenresByUser();
        }

        [HttpGet("monthlyMovies")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SeenMovieRead>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<MonthlyAppUsageModel> GetMonthlySeenMovies()
        {
            return BusinessContext.SeenMovies.GetMonthlySeenMovies();
        }

        [HttpGet("topSeenGenres")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDictionary<string, int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public List<TopGenreModel> GetTopSeenGenres()
        {
            return BusinessContext.SeenMovies.GetTopSeenGenres();
        }

        [HttpGet("topAgeViewership")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDictionary<string, int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  List<AgeViewershipModel> GetTopViewershipByAge()
        {
            return BusinessContext.SeenMovies.GetTopViewershipByAge();
        }
    }
}