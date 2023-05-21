using Library.Models.UserMovieSearch;

namespace BLL.Converters.UserMovieSearch
{
    public class UserMovieSearchReadConverter
    {
        public static UserMovieSearchRead ToBLLModel(DAL.Models.UserMovieSearch userMovieSearchDALModel)
        {
            UserMovieSearchRead userMovieSearchRead = new()
            {
                Uid = userMovieSearchDALModel.UserMovieSearchGUID,
                MovieUid = userMovieSearchDALModel.MovieGUID,
                UserUid = userMovieSearchDALModel.UserGUID,
                CreatedAt = userMovieSearchDALModel.CreatedAt,
            };

            return userMovieSearchRead;
        }

        public static DAL.Models.UserMovieSearch ToDALModel(UserMovieSearchRead userMovieSearchBLLModel)
        {
            DAL.Models.UserMovieSearch userMovieSearchEntity = new()
            {
                UserMovieSearchGUID = userMovieSearchBLLModel.Uid,
                MovieGUID = userMovieSearchBLLModel.MovieUid,
                UserGUID = userMovieSearchBLLModel.UserUid,
                CreatedAt = userMovieSearchBLLModel.CreatedAt
            };

            return userMovieSearchEntity;
        }
    }
}