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

        [HttpGet("{year}/{month}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PredictedGenreRead>))]
        public IActionResult GetAllByDate([FromRoute] int year, [FromRoute] int month)
        {
            return Ok(BusinessContext.PredictedGenres!.GetAllByDate(year, month));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PredictedGenreCreate))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PredictedGenreCreate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Add([FromBody] PredictedGenreCreate predictedGenres)
        {
            return Ok(BusinessContext.PredictedGenres!.Add(predictedGenres));
        }
    }
}