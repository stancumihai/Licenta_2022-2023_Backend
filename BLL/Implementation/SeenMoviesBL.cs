using BLL.Converters.SeenMovie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.SeenMovie;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class SeenMoviesBL : BusinessObject, ISeenMovies
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SeenMoviesBL(DAL.Interfaces.IDALContext dalContext,
            IHttpContextAccessor httpContextAccessor) : base(dalContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public SeenMovieCreate Add(SeenMovieCreate seenMovie)
        {
            SeenMovie addedSeenMovie = SeenMovieCreateConverter.ToDALModel(seenMovie);
            if (addedSeenMovie == null)
            {
                return null;
            }
            return SeenMovieCreateConverter.ToBLLModel(_dalContext.SeenMovies.Add(addedSeenMovie));
        }

        public SeenMovieRead Delete(Guid uid)
        {
            SeenMovie deletedSeenMovie = _dalContext.SeenMovies.Delete(uid);
            if (deletedSeenMovie == null)
            {
                return null;
            }
            return SeenMovieReadConverter.ToBLLModel(deletedSeenMovie);
        }

        public List<SeenMovieRead> GetAll()
        {
            return _dalContext.SeenMovies
               .GetAll()
               .Select(seenMovie => SeenMovieReadConverter.ToBLLModel(seenMovie))
               .ToList();
        }

        public SeenMovieRead? GetByUid(Guid uid)
        {
            SeenMovie seenMovie = _dalContext.SeenMovies.GetByUid(uid);
            if (seenMovie == null)
            {
                return null;
            }
            return SeenMovieReadConverter
                    .ToBLLModel(seenMovie);
        }

        public SeenMovieRead GetByUserAndMovie(Guid movieUid)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            SeenMovie seenMovie = _dalContext.SeenMovies.GetByUserAndMovie(movieUid, userEntity.Id);
            if (seenMovie == null)
            {
                return null;
            }
            SeenMovieRead movieSubscriptionRead = SeenMovieReadConverter.ToBLLModel(seenMovie);
            return movieSubscriptionRead;
        }
    }
}