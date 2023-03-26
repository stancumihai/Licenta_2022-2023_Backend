using Library.Models.MovieRating;

namespace BLL.Converters.MovieRating
{
    public class MovieRatingCreateConverter
    {
        public static MovieRatingCreate ToBLLModel(DAL.Models.MovieRating movieRatingDALModel)
        {
            MovieRatingCreate movieRatingCreate = new()
            {
                MovieUid = movieRatingDALModel.MovieGUID,
                AverageRating = movieRatingDALModel.AverageRating,
                VotesNumber = movieRatingDALModel.VotesNumber,
            };

            return movieRatingCreate;
        }

        public static DAL.Models.MovieRating ToDALModel(MovieRatingCreate moveRatingBLLModel)
        {
            DAL.Models.MovieRating movieRatingEntity = new()
            {
                MovieGUID = moveRatingBLLModel.MovieUid,
                AverageRating = moveRatingBLLModel.AverageRating,
                VotesNumber = moveRatingBLLModel.VotesNumber,
            };

            return movieRatingEntity;
        }
    }
}