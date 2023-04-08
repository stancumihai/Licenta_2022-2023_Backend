using BLL.Converters.MovieSubscription;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.MovieSubscription;

namespace BLL.Implementation
{
    public class MovieSubscriptionsBL : BusinessObject, IMovieSubscriptions
    {
        public MovieSubscriptionsBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public MovieSubscriptionCreate Add(MovieSubscriptionCreate movieSubscription)
        {
            MovieSubscription addedMovieSubscription = MovieSubscriptionCreateConverter.ToDALModel(movieSubscription);
            if (addedMovieSubscription == null)
            {
                return null;
            }
            return MovieSubscriptionCreateConverter.ToBLLModel(_dalContext.MovieSubscriptions.Add(addedMovieSubscription));
        }

        public MovieSubscriptionRead Delete(Guid uid)
        {
            MovieSubscription deletedMovieSubscription = _dalContext.MovieSubscriptions.Delete(uid);
            if (deletedMovieSubscription == null)
            {
                return null;
            }
            return MovieSubscriptionReadConverter.ToBLLModel(deletedMovieSubscription);
        }

        public List<MovieSubscriptionRead> GetAll()
        {
            return _dalContext.MovieSubscriptions
                .GetAll()
                .Select(movieSubscription => MovieSubscriptionReadConverter.ToBLLModel(movieSubscription))
                .ToList();
        }

        public MovieSubscriptionRead? GetByUid(Guid uid)
        {
            MovieSubscription movieSubscription = _dalContext.MovieSubscriptions.GetByUid(uid);
            if (movieSubscription == null)
            {
                return null;
            }
            return MovieSubscriptionReadConverter
                    .ToBLLModel(movieSubscription);
        }

        public MovieSubscriptionRead GetByUserAndMovie(Guid movieUid, string userUid)
        {
            MovieSubscription movieSubscription = _dalContext.MovieSubscriptions.GetByUserAndMovie(movieUid, userUid);
            if (movieSubscription == null)
            {
                return null;
            }
            MovieSubscriptionRead movieSubscriptionRead = MovieSubscriptionReadConverter.ToBLLModel(movieSubscription);
            return movieSubscriptionRead;
        }
    }
}