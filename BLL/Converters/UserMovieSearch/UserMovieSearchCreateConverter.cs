using Library.Models.UserMovieSearch;

namespace BLL.Converters.UserMovieSearch
{
    public class UserMovieSearchCreateConverter
    {
        public static UserMovieSearchCreate ToBLLModel(DAL.Models.UserMovieSearch userMovieSearchDALModel)
        {
            UserMovieSearchCreate userMovieSearchCreate = new()
            {
                MovieUid = userMovieSearchDALModel.MovieGUID,
                UserUid = userMovieSearchDALModel.UserGUID,
                CreatedAt = userMovieSearchDALModel.CreatedAt,
            };

            return userMovieSearchCreate;
        }

        public static DAL.Models.UserMovieSearch ToDALModel(UserMovieSearchCreate userMovieSearchBLLModel)
        {
            DAL.Models.UserMovieSearch userMovieSearchEntity = new()
            {
                MovieGUID = userMovieSearchBLLModel.MovieUid,
                UserGUID = userMovieSearchBLLModel.UserUid,
                CreatedAt = userMovieSearchBLLModel.CreatedAt
            };

            return userMovieSearchEntity;
        }
    }
}