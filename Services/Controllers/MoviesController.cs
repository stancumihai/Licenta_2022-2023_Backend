using Library.Models.Movie;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class MoviesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.Movies!.GetAll());
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetPaginatedMovies([FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            return Ok(BusinessContext.Movies!.GetPaginatedMovies(pageNumber, pageSize));
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            return Ok(BusinessContext.Movies!.GetByUid(uid));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add([FromBody] MovieCreate movie)
        {
            return Ok(BusinessContext.Movies!.Add(movie));
        }

        [HttpGet("person/{personUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetAllByPersonUid([FromRoute] Guid personUid)
        {
            return Ok(BusinessContext.Movies!.GetAllByPersonUid(personUid));
        }

        [HttpGet("genres/{genre}/{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetMoviesByGenre([FromRoute] string genre, [FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            return Ok(BusinessContext.Movies!.GetMoviesByGenre(genre, pageNumber, pageSize));
        }
    }
}