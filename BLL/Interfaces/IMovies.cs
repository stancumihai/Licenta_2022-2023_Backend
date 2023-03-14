using Library.Models.Movie;

namespace BLL.Interfaces
{
    public interface IMovies
    {
        MovieCreate Add(MovieCreate movie);
        List<MovieRead> GetAll();
        MovieRead? GetByUid(Guid uid);
        MovieRead? GetByMovieId(string movieId);
    }
}