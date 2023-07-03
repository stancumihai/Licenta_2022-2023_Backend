using BLL.Converters.Movie;
using Library.Models.LikedMovie;

namespace BLL.Converters.LikedMovie
{
    public class LikedMovieReadConverter
    {
        public static LikedMovieRead ToBLLModel(DAL.Models.LikedMovie likedMovieDALModel)
        {
            LikedMovieRead linkedMovieRead = new()
            {
                Uid = likedMovieDALModel.LikedMovieGUID,
                Movie = MovieReadConverter.ToBLLModel(likedMovieDALModel.Movie),
                UserUid = likedMovieDALModel.UserGUID,
                CreatedAt = likedMovieDALModel.CreatedAt
            };

            return linkedMovieRead;
        }

        public static DAL.Models.LikedMovie ToDALModel(LikedMovieRead likedMovieBLLModel)
        {
            DAL.Models.LikedMovie linkedMovieEntity = new()
            {
                LikedMovieGUID = likedMovieBLLModel.Uid,
                MovieGUID = likedMovieBLLModel.Movie.Uid,
                UserGUID = likedMovieBLLModel.UserUid,
                CreatedAt = likedMovieBLLModel.CreatedAt
            };

            return linkedMovieEntity;
        }
    }
}