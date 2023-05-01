using Library.Models;
using Library.Models.Movie;
using Library.Models.SurveyUserAnswer;
using Library.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Services.Controllers
{
    public class SurveyUserAnswerController : ApiControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SurveyUserAnswerController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyUserAnswerRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public IActionResult GetAllByUser()
        {
            List<SurveyUserAnswerRead> surveyUserAnswers = BusinessContext.SurveyUserAnswers!.GetAllByUser();
            if (surveyUserAnswers == null)
            {
                return NotFound();
            }
            return Ok(surveyUserAnswers);
        }

        [HttpPost("batch")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<string>> AddInSuperBatches([FromBody] SurveyUserAnswerCreateBatch surveyUserAnswerCreateBatch)
        {
            int added = BusinessContext.SurveyUserAnswers!.AddInSuperBatches(surveyUserAnswerCreateBatch);
            List<MovieRead> initialMovieRecommendations = BusinessContext.RecommendationManager.GetInitialMovieRecommendations(surveyUserAnswerCreateBatch);
            if (added == -1)
            {
                return NotFound();
            }
            try
            {
                string? email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
                string body = "<p>Here are the the initial recommendations</p><ul>";
                foreach (MovieRead movie in initialMovieRecommendations)
                {
                    body += $"<li>{movie.Title}</li>";
                }
                body += "</ul>";
                Message? message = new(new string[] { email },
                    "Initial Recommendations",
                    body,
                    null);
                await BusinessContext.EmailSender.SendEmailAsync(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
            return Ok("Recommendations Sent");
        }
    }
}