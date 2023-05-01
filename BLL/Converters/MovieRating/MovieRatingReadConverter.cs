using BLL.Converters.Movie;
using Library.Models.MovieRating;

namespace BLL.Converters.MovieRating
{
    public class MovieRatingReadConverter
    {
        public static MovieRatingRead ToBLLModel(DAL.Models.MovieRating movieRatingDALModel)
        {
            MovieRatingRead movieRatingCreate = new()
            {
                Uid = movieRatingDALModel.MovieRatingGUID,
                Movie =     MovieReadConverter.ToBLLModel(movieRatingDALModel.Movie!),
                AverageRating = movieRatingDALModel.AverageRating,
                VotesNumber = movieRatingDALModel.VotesNumber,
            };

            return movieRatingCreate;
        }

        public static DAL.Models.MovieRating ToDALModel(MovieRatingRead moveRatingBLLModel)
        {
            DAL.Models.MovieRating movieRatingEntity = new()
            {
                MovieRatingGUID = moveRatingBLLModel.Uid,
                MovieGUID = moveRatingBLLModel.Movie.Uid,
                Movie = MovieReadConverter.ToDALModel(moveRatingBLLModel.Movie!),
                AverageRating = moveRatingBLLModel.AverageRating,
                VotesNumber = moveRatingBLLModel.VotesNumber,
            };

            return movieRatingEntity;
        }
    }
}