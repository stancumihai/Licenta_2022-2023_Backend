using Library.Models.SurveyQuestion;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class SurveyQuestionsController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyQuestionRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.SurveyQuestions.GetAll());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyQuestionRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            SurveyQuestionRead? surveyQuestion = BusinessContext.SurveyQuestions.GetByUid(uid);
            if (surveyQuestion == null)
            {
                return NotFound();
            }
            return Ok(surveyQuestion);
        }
    }
}