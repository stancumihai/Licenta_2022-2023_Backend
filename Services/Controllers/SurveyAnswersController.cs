using Library.Models.SurveyAnswer;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class SurveyAnswersController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add([FromBody] SurveyAnswerCreate surveyAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return new ObjectResult(BusinessContext.SurveyAnswers.Add(surveyAnswer)) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyAnswerRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.SurveyQuestions.GetAll());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyAnswerRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            SurveyAnswerRead? surveyAnswer = BusinessContext.SurveyAnswers.GetByUid(uid);
            if (surveyAnswer == null)
            {
                return NotFound();
            }
            return Ok(surveyAnswer);
        }
    }
}