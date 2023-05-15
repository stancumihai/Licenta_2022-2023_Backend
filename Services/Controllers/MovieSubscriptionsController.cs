using Library.Models.Movie;
using Library.Models.MovieSubscription;
using Library.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Services.Controllers
{
    public class MovieSubscriptionsController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieSubscriptionRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.MovieSubscriptions!.GetAll());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieSubscriptionRead))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            return Ok(BusinessContext.MovieSubscriptions!.GetByUid(uid));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MovieSubscriptionCreate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] MovieSubscriptionCreate movieSubscriptionCreate)
        {
            MovieSubscriptionCreate movieSubscription = BusinessContext.MovieSubscriptions!.Add(movieSubscriptionCreate);
            if (movieSubscription == null)
            {
                return BadRequest();
            }
            return Ok(movieSubscription);
        }

        [HttpDelete("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] Guid uid)
        {
            BusinessContext.MovieSubscriptions!.Delete(uid);
            return Ok();
        }

        [HttpGet("movie/user/{movieUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieSubscriptionRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public IActionResult GetByUserAndMovie([FromRoute] Guid movieUid)
        {
            MovieSubscriptionRead movieSubscription = BusinessContext.MovieSubscriptions!.GetByUserAndMovie(movieUid);
            if (movieSubscription == null)
            {
                return NotFound();
            }
            return Ok(movieSubscription);
        }

        [HttpGet("user/{userUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieSubscriptionRead>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public IActionResult GetAllByUser([FromRoute] string userUid)
        {
            List<MovieRead> movieSubscriptions = BusinessContext.MovieSubscriptions!.GetAllByUser(userUid);
            if (movieSubscriptions == null)
            {
                return NotFound();
            }
            return Ok(movieSubscriptions);
        }
    }
}