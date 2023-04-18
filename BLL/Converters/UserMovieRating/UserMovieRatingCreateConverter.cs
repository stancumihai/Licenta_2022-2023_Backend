using Library.Models.UserMovieRatings;

namespace BLL.Converters.UserMovieRating
{
    public class UserMovieRatingCreateConverter
    {
        public static UserMovieRatingCreate ToBLLModel(DAL.Models.UserMovieRating userMovieRatingDALModel)
        {
            UserMovieRatingCreate userMovieRatingRead = new()
            {
                MovieUid = userMovieRatingDALModel.MovieGUID,
                UserUid = userMovieRatingDALModel.UserGUID,
                Rating = userMovieRatingDALModel.Rating
            };

            return userMovieRatingRead;
        }

        public static DAL.Models.UserMovieRating ToDALModel(UserMovieRatingCreate userMovieRatingBLLModel)
        {
            DAL.Models.UserMovieRating userMovieRatingEntity = new()
            {
                MovieGUID = userMovieRatingBLLModel.MovieUid,
                UserGUID = userMovieRatingBLLModel.UserUid,
                Rating = userMovieRatingBLLModel.Rating
            };

            return userMovieRatingEntity;
        }
    }
}