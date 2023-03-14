using Library.Models.Movie;

namespace BLL.Converters.Movie
{
    public class MovieReadConverter
    {
        internal static MovieRead ToBLLModel(DAL.Models.Movie movieDALModel)
        {
            MovieRead movieRead = new()
            {
                Uid = movieDALModel.MovieGUID,
                MovieId = movieDALModel.MovieId,
                Title = movieDALModel.Title,
                YearOfRelease = movieDALModel.YearOfRelease,
                Runtime = movieDALModel.Runtime,
                Genres = movieDALModel.Genres
            };

            return movieRead;
        }

        internal static DAL.Models.Movie ToBLLModel(MovieRead movieBLLModel)
        {
            DAL.Models.Movie movieRead = new()
            {
                Uid = movieBLLModel.MovieGUID,
                MovieId = movieBLLModel.MovieId,
                Title = movieBLLModel.Title,
                YearOfRelease = movieBLLModel.YearOfRelease,
                Runtime = movieBLLModel.Runtime,
                Genres = movieBLLModel.Genres
            };

            return movieRead;
        }
    }
}