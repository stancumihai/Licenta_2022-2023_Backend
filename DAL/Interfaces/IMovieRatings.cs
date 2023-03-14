using DAL.Models;

namespace DAL.Interfaces
{
    public interface IMovieRatings
    {
        MovieRating Add(MovieRating movie);
        List<MovieRating> GetAll();
        MovieRating? GetByUid(Guid uid);
        MovieRating? GetByMovieUid(Guid movieUid);
    }
}