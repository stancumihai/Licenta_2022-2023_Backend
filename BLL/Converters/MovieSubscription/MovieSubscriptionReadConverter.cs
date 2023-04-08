using BLL.Converters.Movie;
using Library.Models.MovieSubscription;

namespace BLL.Converters.MovieSubscription
{
    public class MovieSubscriptionReadConverter
    {
        public static MovieSubscriptionRead ToBLLModel(DAL.Models.MovieSubscription movieSubscriptionDALModel)
        {
            MovieSubscriptionRead movieSubscription = new()
            {
                Uid = movieSubscriptionDALModel.MovieSubscriptionGUID,
                Movie = MovieReadConverter.ToBLLModel(movieSubscriptionDALModel.Movie),
                UserGUID = movieSubscriptionDALModel.UserGUID
            };

            return movieSubscription;
        }

        public static DAL.Models.MovieSubscription ToDALModel(MovieSubscriptionRead likedMovieBLLModel)
        {
            DAL.Models.MovieSubscription linkedMovieEntity = new()
            {
                MovieSubscriptionGUID = likedMovieBLLModel.Uid,
                MovieGUID = likedMovieBLLModel.Movie.Uid,
                UserGUID = likedMovieBLLModel.UserGUID
            };

            return linkedMovieEntity;
        }
    }
}