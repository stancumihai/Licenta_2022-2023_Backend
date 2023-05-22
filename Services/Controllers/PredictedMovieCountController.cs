using Library.Models.PredictedMovieCount;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PredictedMovieCountController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedMovieCountRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.PredictedMoviesCount!.GetAll());
        }

        [HttpGet("{year}/{month}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedMovieCountRead>))]
        public IActionResult GetAllByDate([FromRoute] int year, [FromRoute] int month)
        {
            return Ok(BusinessContext.PredictedMoviesCount!.GetAllByDate(year, month));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PredictedMovieCountCreate))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PredictedMovieCountCreate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Add([FromBody] PredictedMovieCountCreate predictedMovieCount)
        {
            return Ok(BusinessContext.PredictedMoviesCount!.Add(predictedMovieCount));
        }
    }
}