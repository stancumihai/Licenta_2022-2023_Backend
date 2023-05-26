using Library.Models._UI;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PredictedAgesViewershipController : ApiControllerBase
    {
        [HttpGet("{year}/{month}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AgeViewershipModel>))]
        public IActionResult GetByMonth([FromRoute] int year, [FromRoute] int month)
        {
            return Ok(BusinessContext.PredictedAgesViewership!.GetByMonth(year, month));
        }
    }
}
