using Library.Models.MovieRating;

namespace BLL.Interfaces
{
    public interface IMovieRatings
    {
        void Add(MovieRatingCreate movie);
        List<MovieRatingRead> GetAll();
        MovieRatingRead? GetByUid(Guid uid);
        MovieRatingRead? GetByMovieUid(Guid movieUid);
        MovieRatingRead? Update(MovieRatingRead movieRatingRead);
    }
}