using Library.Models.UserMovieRatings;

namespace BLL.Converters.UserMovieRating
{
    public class UserMovieRatingReadConverter
    {
        public static UserMovieRatingRead ToBLLModel(DAL.Models.UserMovieRating userMovieRatingDALModel)
        {
            UserMovieRatingRead userMovieRatingRead = new()
            {
                Uid = userMovieRatingDALModel.UserMovieRatingGUID,
                MovieUid = userMovieRatingDALModel.MovieGUID,
                UserUid = userMovieRatingDALModel.UserGUID,
                Rating = userMovieRatingDALModel.Rating
            };

            return userMovieRatingRead;
        }

        public static DAL.Models.UserMovieRating ToDALModel(UserMovieRatingRead userMovieRatingBLLModel)
        {
            DAL.Models.UserMovieRating userMovieRatingEntity = new()
            {
                UserMovieRatingGUID = userMovieRatingBLLModel.Uid,
                MovieGUID = userMovieRatingBLLModel.MovieUid,
                UserGUID = userMovieRatingBLLModel.UserUid,
                Rating = userMovieRatingBLLModel.Rating
            };

            return userMovieRatingEntity;
        }
    }
}