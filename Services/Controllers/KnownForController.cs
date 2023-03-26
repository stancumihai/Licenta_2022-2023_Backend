using Library.Models.KnownFor;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using System.Net;

namespace Services.Controllers
{
    public class KnownForController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<KnownForRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.KnownFor!.GetAll());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(KnownForRead))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            KnownForRead? knownForRead = BusinessContext.KnownFor!.GetByUid(uid);
            if (knownForRead == null)
            {
                var response = new HttpResponseException((int)HttpStatusCode.NotFound, "Known Data Not Found");
                return BadRequest(response);
            }
            return Ok(knownForRead);    
        }
    }
}