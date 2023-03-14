using Library.Models.Movie;

namespace BLL.Converters.Movie
{
    public class MovieCreateConverter
    {
        public static MovieCreate ToBLLModel(DAL.Models.Movie movieDALModel)
        {
            MovieCreate movieCreate = new()
            {
                MovieId = movieDALModel.MovieId,
                Title = movieDALModel.Title,
                YearOfRelease = movieDALModel.YearOfRelease,
                Runtime = movieDALModel.Runtime,
                Genres = movieDALModel.Genres
            };

            return movieCreate;
        }

        public static DAL.Models.Movie ToDALModel(MovieCreate movieBLLModel)
        {
            DAL.Models.Movie movieEntity = new()
            {
                MovieId = movieBLLModel.MovieId,
                Title = movieBLLModel.Title,
                YearOfRelease = movieBLLModel.YearOfRelease,
                Runtime = movieBLLModel.Runtime,
                Genres = movieBLLModel.Genres
            };

            return movieEntity;
        }
    }
}