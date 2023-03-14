using Library.Models.MovieRating;

namespace BLL.Converters.MovieRating
{
    public class MovieRatingCreateConverter
    {
        public static MovieRatingCreate ToBLLModel(DAL.Models.MovieRating movieRatingDALModel)
        {
            MovieRatingCreate movieRatingCreate = new()
            {
                MovieRatingUid = movieRatingDALModel.MovieRatingGUID,
                AverageRating = movieRatingDALModel.AverageRating,
                VotesNumber = movieRatingDALModel.VotesNumber,
            };

            return movieRatingCreate;
        }

        public static DAL.Models.MovieRating ToDALModel(MovieRatingCreate moveRatingBLLModel)
        {
            DAL.Models.MovieRating movieRatingEntity = new()
            {
                MovieRatingGUID = moveRatingBLLModel.MovieRatingUid,
                AverageRating = moveRatingBLLModel.AverageRating,
                VotesNumber = moveRatingBLLModel.VotesNumber,
            };

            return movieRatingEntity;
        }
    }
}