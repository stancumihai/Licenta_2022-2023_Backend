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
            return Ok(BusinessContext.SurveyAnswers!.Add(surveyAnswer));
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyAnswerRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.SurveyAnswers!.GetAll());
        }

        [HttpGet("question/{questionUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyAnswerRead>))]
        public IActionResult GetAllByQuestionUid([FromRoute] Guid questionUid)
        {
            return Ok(BusinessContext.SurveyAnswers!.GetAllByQuestionUid(questionUid));
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SurveyAnswerRead))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            SurveyAnswerRead? surveyAnswer = BusinessContext.SurveyAnswers!.GetByUid(uid);
            if (surveyAnswer == null)
            {
                return NotFound();
            }
            return Ok(surveyAnswer);
        }
    }
}