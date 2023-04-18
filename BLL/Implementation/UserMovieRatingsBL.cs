using BLL.Converters.UserMovieRating;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.UserMovieRatings;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class UserMovieRatingsBL : BusinessObject, IUserMovieRatings
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserMovieRatingsBL(DAL.Interfaces.IDALContext dalContext,
            IHttpContextAccessor httpContextAccessor) : base(dalContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserMovieRatingCreate? Add(UserMovieRatingCreate userMovieRating)
        {
            UserMovieRating addedUserMovieRating = _dalContext.UserMovieRatings.Add(UserMovieRatingCreateConverter.ToDALModel(userMovieRating))!;
            if (addedUserMovieRating == null)
            {
                return null;
            }
            return UserMovieRatingCreateConverter.ToBLLModel(addedUserMovieRating);
        }

        public void Delete(Guid guid)
        {
            _dalContext.UserMovieRatings.Delete(guid);
        }

        public List<UserMovieRatingRead> GeAllByLoggedUser()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            return _dalContext.UserMovieRatings
              .GeAllByLoggedUser(userEntity.Id)
              .Select(userMovieRating => UserMovieRatingReadConverter.ToBLLModel(userMovieRating))
              .ToList();
        }

        public List<UserMovieRatingRead> GetAll()
        {
            return _dalContext.UserMovieRatings
              .GetAll()
              .Select(userMovieRating => UserMovieRatingReadConverter.ToBLLModel(userMovieRating))
              .ToList();
        }

        public UserMovieRatingRead GetByUid(Guid guid)
        {
            UserMovieRating foundUser = _dalContext.UserMovieRatings
               .GetByUid(guid);
            if (foundUser == null)
            {
                return null;
            }
            return UserMovieRatingReadConverter.ToBLLModel(foundUser);
        }

        public UserMovieRatingRead? Update(UserMovieRatingRead newUserMovieRating)
        {
            UserMovieRating? userToBeUpdated = _dalContext
                .UserMovieRatings
                .Update(UserMovieRatingReadConverter.ToDALModel(newUserMovieRating));

            return UserMovieRatingReadConverter.ToBLLModel(userToBeUpdated);
        }
    }
}