using BLL.Converters.LikedMovie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.LikedMovie;

namespace BLL.Implementation
{
    public class LikedMoviesBL : BusinessObject, ILikedMovies
    {
        public LikedMoviesBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public LikedMovieCreate Add(LikedMovieCreate likedMovie)
        {
            LikedMovie addedLikedMovie = LikedMovieCreateConverter.ToDALModel(likedMovie);
            if(addedLikedMovie == null)
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

        public List<LikedMovieRead> GetAllByLoggedUser(string userUid)
        {

            List<LikedMovie> likedMovies = _dalContext.LikedMovies
                .GetAllByLoggedUser(userUid);
            if (likedMovies == null)
            {
                return null;
            }
            List<LikedMovieRead> likedMoviesRead = likedMovies
            .Select(likedMovie => LikedMovieReadConverter.ToBLLModel(likedMovie))
            .ToList();
            return likedMoviesRead;
        }

        public LikedMovieRead GetByUserAndMovie(Guid movieUid, string userUid)
        {
            LikedMovie likedMovie = _dalContext.LikedMovies.GetByUserAndMovie(movieUid, userUid);
            if(likedMovie == null)
            {
                return null;
            }
            LikedMovieRead likedMovieRead = LikedMovieReadConverter.ToBLLModel(likedMovie);
            return likedMovieRead;
        }
    }
}