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
    }
}