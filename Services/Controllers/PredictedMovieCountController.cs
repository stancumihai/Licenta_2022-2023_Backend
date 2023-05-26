using Library.Models.PredictedMovieCount;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PredictedMoviesCountController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedMovieCountRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.PredictedMoviesCount!.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PredictedMovieCountCreate))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PredictedMovieCountCreate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Add([FromBody] PredictedMovieCountCreate predictedMovieCount)
        {
            return Ok(BusinessContext.PredictedMoviesCount.Add(predictedMovieCount));
        }

        [HttpGet("eachMonth/{userUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Library.Models._UI.MachineLearning.PredictedMovieCount>))]
        public IActionResult GetEachMonthByUser([FromRoute] string userUid)
        {
            return Ok(BusinessContext.PredictedMoviesCount.GetEachMonthByUser(userUid));
        }

        [HttpGet("eachMonth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Library.Models._UI.MachineLearning.PredictedMovieCount>))]
        public IActionResult GetEachMonth()
        {
            return Ok(BusinessContext.PredictedMoviesCount.GetEachMonth());
        }
    }
}