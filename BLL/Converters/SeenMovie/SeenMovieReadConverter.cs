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
                UserUid = seenMovieDALModel.UserGUID,
                CreatedAt = seenMovieDALModel.CreatedAt
            };

            return seenMovieRead;
        }

        public static DAL.Models.SeenMovie ToDALModel(SeenMovieRead seenMovieBLLModel)
        {
            DAL.Models.SeenMovie seenMovieEntity = new()
            {
                SeenMovieGUID = seenMovieBLLModel.Uid,
                MovieGUID = seenMovieBLLModel.Movie.Uid,
                UserGUID = seenMovieBLLModel.UserUid,
                CreatedAt = seenMovieBLLModel.CreatedAt
            };

            return seenMovieEntity;
        }
    }
}