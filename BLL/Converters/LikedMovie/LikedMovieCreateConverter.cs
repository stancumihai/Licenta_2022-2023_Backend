using Library.Models.LikedMovie;

namespace BLL.Converters.LikedMovie
{
    public class LikedMovieCreateConverter
    {
        public static LikedMovieCreate ToBLLModel(DAL.Models.LikedMovie likedMovieDALModel)
        {
            LikedMovieCreate linkedMovieCreate = new()
            {
                MovieUid = likedMovieDALModel.MovieGUID,
                UserUid = likedMovieDALModel.UserGUID
            };

            return linkedMovieCreate;
        }

        public static DAL.Models.LikedMovie ToDALModel(LikedMovieCreate likedMovieBLLModel)
        {
            DAL.Models.LikedMovie linkedMovieEntity = new()
            {
                MovieGUID = likedMovieBLLModel.MovieUid,
                UserGUID = likedMovieBLLModel.UserUid
            };

            return linkedMovieEntity;
        }
    }
}