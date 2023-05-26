using Library.Models.PredictedGenre;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PredictedGenresController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedGenreRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.PredictedGenres!.GetAll());
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PredictedGenreCreate))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PredictedGenreCreate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Add([FromBody] PredictedGenreCreate predictedGenres)
        {
            return Ok(BusinessContext.PredictedGenres!.Add(predictedGenres));
        }

        [HttpGet("eachMonth/{userUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Library.Models._UI.MachineLearning.PredictedGenre>))]
        public IActionResult GetEachMonthByUser([FromRoute] string userUid)
        {
            return Ok(BusinessContext.PredictedGenres!.GetEachMonthByUser(userUid));
        }

        [HttpGet("eachMonth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Library.Models._UI.MachineLearning.PredictedGenre>))]
        public IActionResult GetEachMonth()
        {
            return Ok(BusinessContext.PredictedGenres!.GetEachMonth());
        }
    }
}