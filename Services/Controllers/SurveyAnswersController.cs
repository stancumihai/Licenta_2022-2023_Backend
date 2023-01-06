using Library.Models.SurveyAnswer;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class SurveyAnswersController : ApiControllerBase
    {
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