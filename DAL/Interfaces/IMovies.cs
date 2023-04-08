using DAL.Models;

namespace DAL.Interfaces
{
    public interface IMovies
    {
        Movie Add(Movie movie);
        List<Movie> GetAll();
        Movie? GetByUid(Guid uid);
        Movie? GetByMovieId(string movieId);
        List<Movie> GetPaginatedMovies(int pageNumber, int pageSize);
        List<Movie> GetAllByPersonUid(Guid personGuid);
        List<Movie> GetMoviesByGenre(string genre, int pageNumber, int pageSize);
        List<string> GetMovieGenres();
    }
}