using Library.Models.Movie;

namespace BLL.Interfaces
{
    public interface IMovies
    {
        MovieCreate Add(MovieCreate movie);
        List<MovieRead> GetAll();
        MovieRead? GetByUid(Guid uid);
        MovieRead? GetByMovieId(string movieId);
        List<MovieRead> GetPaginatedMovies(int pageNumber, int pageSize);
        List<MovieRead> GetAllByPersonUid(Guid personGuid);
        List<MovieRead> GetMoviesByGenre(string genre, int pageNumber, int pageSize);
    }
}