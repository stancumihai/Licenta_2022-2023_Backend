using Library.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PersonController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.Persons!.GetAll());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            return Ok(BusinessContext.Persons!.GetByUid(uid));
        }
    }
}