using Library.Models;
using Library.Models.Movie;
using Library.Models.Recommendation;
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
        public async Task<ActionResult<List<RecommendationRead>>> AddInSuperBatches([FromBody] SurveyUserAnswerCreateBatch surveyUserAnswerCreateBatch)
        {
            int added = BusinessContext.SurveyUserAnswers!.AddInSuperBatches(surveyUserAnswerCreateBatch);
            if (added == -1)
            {
                return NotFound();
            }
            string? email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            List<MovieRead> initialMovieRecommendations = BusinessContext.RecommendationManager.GetInitialMovieRecommendations(surveyUserAnswerCreateBatch);
            List<RecommendationRead> recommendations = initialMovieRecommendations.Select(m => new RecommendationRead
            {
                Uid = new Guid(),
                Movie = m,
                UserUid = BusinessContext.Users.GetByEmail(email).Uid.ToString(),
                CreatedAt = DateTime.Now
            }).ToList();
            foreach (RecommendationRead recommendationRead in recommendations)
            {
                BusinessContext.Recommendations.Add(new RecommendationCreate
                {
                    MovieUid = recommendationRead.Movie.Uid,
                    UserUid = recommendationRead.UserUid,
                    CreatedAt = recommendationRead.CreatedAt,
                    IsLiked = recommendationRead.IsLiked,
                    LikedDecisionDate = recommendationRead.LikedDecisionDate
                });
            }
            try
            {
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
                Console.WriteLine(e);
                return Ok(recommendations);

            }
            return Ok(recommendations);
        }
    }
}