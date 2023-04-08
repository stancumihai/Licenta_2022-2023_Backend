using Library.Models.SeenMovie;

namespace BLL.Interfaces
{
    public interface ISeenMovies
    {
        SeenMovieCreate Add(SeenMovieCreate movieSubscription);
        List<SeenMovieRead> GetAll();
        SeenMovieRead? GetByUid(Guid uid);
        SeenMovieRead Delete(Guid uid);
        SeenMovieRead GetByUserAndMovie(Guid movieUid, string userGUID);
    }
}