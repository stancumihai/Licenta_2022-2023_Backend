using Library.Models.AlgorithmChange;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class AlgorithmChangesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AlgorithmChangeRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.AlgorithmChanges!.GetAll());
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<AlgorithmChangeCreate>))]
        public IActionResult Add([FromBody] AlgorithmChangeCreate algorithmChange)
        {
            return Ok(BusinessContext.AlgorithmChanges!.Add(algorithmChange));
        }
    }
}