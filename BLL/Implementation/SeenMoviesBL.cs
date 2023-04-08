using BLL.Converters.SeenMovie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.SeenMovie;

namespace BLL.Implementation
{
    public class SeenMoviesBL : BusinessObject, ISeenMovies
    {
        public SeenMoviesBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
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

        public SeenMovieRead GetByUserAndMovie(Guid movieUid, string userGUID)
        {
            SeenMovie seenMovie = _dalContext.SeenMovies.GetByUserAndMovie(movieUid, userGUID);
            if (seenMovie == null)
            {
                return null;
            }
            SeenMovieRead movieSubscriptionRead = SeenMovieReadConverter.ToBLLModel(seenMovie);
            return movieSubscriptionRead;
        }
    }
}