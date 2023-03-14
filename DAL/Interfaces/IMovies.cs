using DAL.Models;

namespace DAL.Interfaces
{
    public interface IMovies
    {
        Movie Add(Movie movie);
        List<Movie> GetAll();
        Movie? GetByUid(Guid uid);
    }
}