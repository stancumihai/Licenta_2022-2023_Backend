using Library.Models.MovieRating;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class MovieRatingsController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRatingRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.MovieRatings!.GetAll());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRatingRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            return Ok(BusinessContext.MovieRatings!.GetByUid(uid));
        }

        [HttpGet("movie/{movieUid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRatingRead>))]
        public IActionResult GetByMovieUid([FromRoute] Guid movieUid)
        {
            return Ok(BusinessContext.MovieRatings!.GetByMovieUid(movieUid));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRatingRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Update([FromBody] MovieRatingRead movieRatingRead)
        {
            MovieRatingRead? newMovieRating = BusinessContext.MovieRatings!.Update(movieRatingRead);
            if(newMovieRating == null)
            {
                return NotFound();
            }
            return Ok(newMovieRating);
        }
    }
}