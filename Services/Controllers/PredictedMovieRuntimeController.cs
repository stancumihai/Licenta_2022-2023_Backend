using Library.Models.PredictedMovieRuntime;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PredictedMovieRuntimeController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedMovieRuntimeRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.PredictedMoviesRuntime!.GetAll());
        }

        [HttpGet("{year}/{month}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedMovieRuntimeRead>))]
        public IActionResult GetAllByDate([FromRoute] int year, [FromRoute] int month)
        {
            return Ok(BusinessContext.PredictedMoviesRuntime!.GetAllByDate(year, month));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PredictedMovieRuntimeCreate))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PredictedMovieRuntimeCreate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Add([FromBody] PredictedMovieRuntimeCreate predictedMovieRuntime)
        {
            return Ok(BusinessContext.PredictedMoviesRuntime!.Add(predictedMovieRuntime));
        }
    }
}