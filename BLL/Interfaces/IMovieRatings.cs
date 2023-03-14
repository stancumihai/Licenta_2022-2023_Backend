using DAL.Models;
using Library.Models.MovieRating;

namespace BLL.Interfaces
{
    public interface IMovieRatings
    {
        MovieRatingCreate Add(MovieRatingCreate movie);
        List<MovieRatingRead> GetAll();
        MovieRatingRead? GetByUid(Guid uid);
        MovieRatingRead? GetByMovieUid(Guid movieUid);
    }
}