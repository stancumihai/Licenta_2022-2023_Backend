using Library.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class PersonsController : ApiControllerBase
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

        [HttpGet("movie/{movieUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonRead>))]
        public IActionResult GetAllByMovieUid([FromRoute] Guid movieUid)
        {
            return Ok(BusinessContext.Persons!.GetAllByMovieUid(movieUid));
        }

        [HttpGet("profession/{profession}/{pageNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonRead>))]
        public IActionResult GetPaginatedPersonsByProfession([FromRoute] string profession, [FromRoute] int pageNumber)
        {
            return Ok(BusinessContext.Persons!.GetPaginatedPersonsByProfession(profession, pageNumber));
        }
    }
}