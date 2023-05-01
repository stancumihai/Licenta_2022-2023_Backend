using Library.Models.UserMovieRatings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class UserMovieRatingsController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserMovieRatingRead>))]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.UserMovieRatings!.GetAll());
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserMovieRatingRead>))]
        [Authorize]
        public IActionResult GeAllByLoggedUser()
        {
            List<UserMovieRatingRead> userMovieRatings = BusinessContext.UserMovieRatings.GeAllByLoggedUser();
            if (userMovieRatings == null)
            {
                NotFound();
            }
            return Ok(BusinessContext.UserMovieRatings.GeAllByLoggedUser());
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserMovieRatingRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            UserMovieRatingRead userMovieRating = BusinessContext.UserMovieRatings.GetByUid(uid);
            if (userMovieRating == null)
            {
                NotFound();
            }
            return Ok(userMovieRating);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserMovieRatingRead))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] UserMovieRatingRead newUserMovieRating)
        {
            UserMovieRatingRead userMovieRating = BusinessContext.UserMovieRatings!.Update(newUserMovieRating)!;
            if (userMovieRating == null)
            {
                return BadRequest();
            }
            return Ok(userMovieRating);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserMovieRatingCreate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] UserMovieRatingCreate userMovieRating)
        {
            UserMovieRatingCreate addedUserMovieRating = BusinessContext.UserMovieRatings!.Add(userMovieRating)!;
            if (addedUserMovieRating == null)
            {
                return BadRequest();
            }
            return Ok(addedUserMovieRating);
        }

        [HttpDelete("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] Guid uid)
        {
            BusinessContext.UserMovieRatings.Delete(uid);
            return NoContent();
        }

        [HttpGet("movie/{movieUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserMovieRatingRead))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetByMovieAndUser([FromRoute] Guid movieUid)
        {
            UserMovieRatingRead? userMovieRating = BusinessContext.UserMovieRatings.GetByMovieAndUser(movieUid);
            if(userMovieRating == null)
            {
                return NotFound();
            }
            return Ok(userMovieRating);
        }
    }
}