using Library.Models.SurveyQuestion;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Services.Controllers
{
    public class SurveyQuestionsController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyQuestionRead>))]
        public IActionResult GetAll()
        {
            var surveyQuestions = BusinessContext.SurveyQuestions!.GetAll();
            if (surveyQuestions == null)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, "My error message");
            }
            return Ok(surveyQuestions);
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyQuestionRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            SurveyQuestionRead? surveyQuestion = BusinessContext.SurveyQuestions!.GetByUid(uid);
            if (surveyQuestion == null)
            {
                return NotFound();
            }
            return Ok(surveyQuestion);
        }

        [HttpGet("surveyAnswerGuid/{surveyAnswerUid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyQuestionRead>))]
        public IActionResult GetGuidBySurveyAnswerGuid([FromRoute] Guid surveyAnswerUid)
        {
            Guid surveyQuestionUid = BusinessContext.SurveyQuestions!.GetGuidBySurveyAnswerGuid(surveyAnswerUid);
            if (surveyQuestionUid == Guid.Empty)
            {
                return NotFound();
            }
            return Ok(surveyQuestionUid);
        }
    }
}