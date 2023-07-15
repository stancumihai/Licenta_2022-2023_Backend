using BLL.Core;
using Library.Models._UI;
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
        [HttpGet("accuracy/perMonths/{algorithmName}")]
        public IActionResult GetAccuracyPerMonthsByAlgorithm([FromRoute] string algorithmName)
        {
            return Ok(BusinessContext.Recommendations.GetAccuracyPerMonthsByAlgorithm(algorithmName));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MonthlyRecommendationStatusModel>))]
        [HttpGet("accuracy/monthlyStatus/{year}/{month}/{algorithmName}")]
        public IActionResult GetMonthlyRecommendationStatuses([FromRoute] int year, [FromRoute] int month, [FromRoute] string algorithmName)
        {
            return Ok(BusinessContext.Recommendations.GetMonthlyRecommendationStatuses(year, month, algorithmName));
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MonthlyRecommendationStatusModel>))]
        [HttpGet("monthlySummaries")]
        public List<SummaryMonthlyStatistics> GetMonthlySummaries()
        {
            return BusinessContext.Recommendations.GetMonthlySummaries();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RecommendationRead>))]
        [HttpGet("{userUid}/{year}/{month}")]
        public IActionResult GetAllByUserAndMonth([FromRoute] string userUid, [FromRoute] int year, int month)
        {
            return Ok(BusinessContext.Recommendations.GetAllByUserAndMonth(userUid, year, month));

        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RecommendationRead>))]
        [HttpGet("{year}/{month}")]
        public IActionResult GetAllByMonth([FromRoute] int year, int month)
        {
            return Ok(BusinessContext.Recommendations.GetAllByMonth(year, month));
        }
    }
}