using Library.Models;
using Library.Models.SurveyUserAnswer;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Services.Controllers
{
    public class SurveyUserAnswerController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyUserAnswerRead>))]
        public IActionResult GetAll()
        {
            var surveyUserAnswers = BusinessContext.SurveyUserAnswers!.GetAll();
            if (surveyUserAnswers == null)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, "My error message");
            }
            return Ok(surveyUserAnswers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add([FromBody] SurveyUserAnswerCreate surveyUserAnswer)
        {
            return Ok(BusinessContext.SurveyUserAnswers!
                .Add(surveyUserAnswer));
        }
    }
}