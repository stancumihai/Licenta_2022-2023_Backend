using Library.Models.UserMovieSearch;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class UserMovieSearchesController : ApiControllerBase
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public IActionResult Add([FromBody] UserMovieSearchCreate userMovieSearchCreate)
        {
            UserMovieSearchCreate? addedUserMovieSearch = BusinessContext.UserMovieSearches.Add(userMovieSearchCreate);
            if (addedUserMovieSearch == null)
            {
                return NotFound();
            }
            return Ok(addedUserMovieSearch);
        }
    }
}