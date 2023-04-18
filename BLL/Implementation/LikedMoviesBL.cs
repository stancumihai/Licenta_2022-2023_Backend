using BLL.Converters.LikedMovie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.LikedMovie;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class LikedMoviesBL : BusinessObject, ILikedMovies
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LikedMoviesBL(DAL.Interfaces.IDALContext dalContext,
            IHttpContextAccessor httpContextAccessor) : base(dalContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public LikedMovieCreate Add(LikedMovieCreate likedMovie)
        {
            LikedMovie addedLikedMovie = LikedMovieCreateConverter.ToDALModel(likedMovie);
            if (addedLikedMovie == null)
            {
                return null;
            }
            return LikedMovieCreateConverter.ToBLLModel(_dalContext.LikedMovies.Add(addedLikedMovie));
        }

        public void Delete(Guid uid)
        {
            _dalContext.LikedMovies.Delete(uid);
        }

        public List<LikedMovieRead> GetAll()
        {
            return _dalContext.LikedMovies
              .GetAll()
              .Select(likedMovie => LikedMovieReadConverter.ToBLLModel(likedMovie))
              .ToList();
        }

        public LikedMovieRead? GetByUid(Guid uid)
        {
            return LikedMovieReadConverter
                    .ToBLLModel(_dalContext.LikedMovies
                    .GetByUid(uid)!);
        }

        public List<LikedMovieRead> GetAllByLoggedUser()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            List<LikedMovie> likedMovies = _dalContext.LikedMovies
                .GetAllByLoggedUser(userEntity.Id);
            if (likedMovies == null)
            {
                return null;
            }
            List<LikedMovieRead> likedMoviesRead = likedMovies
            .Select(likedMovie => LikedMovieReadConverter.ToBLLModel(likedMovie))
            .ToList();
            return likedMoviesRead;
        }

        public LikedMovieRead GetByUserAndMovie(Guid movieUid)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            LikedMovie likedMovie = _dalContext.LikedMovies.GetByUserAndMovie(movieUid, userEntity.Id);
            if (likedMovie == null)
            {
                return null;
            }
            LikedMovieRead likedMovieRead = LikedMovieReadConverter.ToBLLModel(likedMovie);
            return likedMovieRead;
        }
    }
}