using Library.Models.PredictedMovieRuntime;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PredictedMoviesRuntimeController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedMovieRuntimeRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.PredictedMoviesRuntime!.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PredictedMovieRuntimeCreate))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PredictedMovieRuntimeCreate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Add([FromBody] PredictedMovieRuntimeCreate predictedMovieRuntime)
        {
            return Ok(BusinessContext.PredictedMoviesRuntime!.Add(predictedMovieRuntime));
        }

        [HttpGet("eachMonth/{userUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Library.Models._UI.MachineLearning.PredictedMovieRuntime>))]
        public IActionResult GetEachMonthByUser([FromRoute] string userUid)
        {
            return Ok(BusinessContext.PredictedMoviesRuntime.GetEachMonthByUser(userUid));
        }

        [HttpGet("eachMonth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Library.Models._UI.MachineLearning.PredictedMovieRuntime>))]
        public IActionResult GetEachMonth()
        {
            return Ok(BusinessContext.PredictedMoviesRuntime.GetEachMonth());
        }
    }
}