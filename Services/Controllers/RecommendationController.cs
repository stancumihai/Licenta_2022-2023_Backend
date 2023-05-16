using BLL.Core;
using Library.Models;
using Library.Models.Recommendation;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class RecommendationsController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RecommendationRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.Recommendations!.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RecommendationRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public IActionResult Update([FromBody] RecommendationUpdate recommendation)
        {
            RecommendationRead? recommendationRead = BusinessContext.Recommendations.Update(recommendation);
            if (recommendationRead == null)
            {
                return NotFound();
            }
            return Ok(recommendationRead);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(float))]
        [HttpGet("accuracy/{userUid}")]
        public IActionResult GetAccuracyByUser([FromRoute] string userUid)
        {
            return Ok(BusinessContext.Recommendations.GetAccuracyByUser(userUid));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AccuracyPeriodModel>))]
        [HttpGet("accuracy/perMonths")]
        public IActionResult GetAccuracyPerMonths()
        {
            return Ok(BusinessContext.Recommendations.GetAccuracyPerMonths());
        }
    }
}