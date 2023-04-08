using BLL.Converters.Movie;
using Library.Models.LikedMovie;

namespace BLL.Converters.LikedMovie
{
    public class LikedMovieReadConverter
    {
        public static LikedMovieRead ToBLLModel(DAL.Models.LikedMovie likedMovieDALModel)
        {
            LikedMovieRead linkedMovieCreate = new()
            {
                Uid = likedMovieDALModel.LikedMovieGUID,
                Movie = MovieReadConverter.ToBLLModel(likedMovieDALModel.Movie),
                UserGUID = likedMovieDALModel.UserGUID
            };

            return linkedMovieCreate;
        }

        public static DAL.Models.LikedMovie ToDALModel(LikedMovieRead likedMovieBLLModel)
        {
            DAL.Models.LikedMovie linkedMovieEntity = new()
            {
                LikedMovieGUID = likedMovieBLLModel.Uid,
                MovieGUID = likedMovieBLLModel.Movie.Uid,
                UserGUID = likedMovieBLLModel.UserGUID
            };

            return linkedMovieEntity;
        }
    }
}