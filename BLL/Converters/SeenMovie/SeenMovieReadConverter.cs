using BLL.Converters.Movie;
using Library.Models.SeenMovie;

namespace BLL.Converters.SeenMovie
{
    public class SeenMovieReadConverter
    {
        public static SeenMovieRead ToBLLModel(DAL.Models.SeenMovie seenMovieDALModel)
        {
            SeenMovieRead seenMovieRead = new()
            {
                Uid = seenMovieDALModel.SeenMovieGUID,
                Movie = MovieReadConverter.ToBLLModel(seenMovieDALModel.Movie),
                UserGUID = seenMovieDALModel.UserGUID
            };

            return seenMovieRead;
        }

        public static DAL.Models.SeenMovie ToDALModel(SeenMovieRead seenMovieBLLModel)
        {
            DAL.Models.SeenMovie movieSubscriptionEntity = new()
            {
                SeenMovieGUID = seenMovieBLLModel.Uid,
                MovieGUID = seenMovieBLLModel.Movie.Uid,
                UserGUID = seenMovieBLLModel.UserGUID
            };

            return movieSubscriptionEntity;
        }
    }
}