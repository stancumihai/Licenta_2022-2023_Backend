using Library.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class UserProfilesController : ApiControllerBase
    {
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public IActionResult Add([FromBody] UserProfileCreate userProfileCreate)
        {
            UserProfileCreate? userProfile = BusinessContext.UserProfiles.Add(userProfileCreate);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public IActionResult Update([FromBody] UserProfileUpdate userProfileUpdate)
        {
            UserProfileRead? userProfile = BusinessContext.UserProfiles.Update(userProfileUpdate);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(BusinessContext.UserProfiles.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{userProfileUid}")]
        public IActionResult GetByUid([FromRoute] Guid userProfileUid)
        {
            UserProfileRead? userProfile = BusinessContext.UserProfiles.GetByGuid(userProfileUid);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("user/{userUid}")]
        public IActionResult GetByUserGuid([FromRoute] string userUid)
        {
            return Ok(BusinessContext.UserProfiles.GetByUserGuid(userUid));
        }
    }
}