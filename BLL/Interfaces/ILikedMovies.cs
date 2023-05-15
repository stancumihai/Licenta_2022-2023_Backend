using Library.Models.LikedMovie;
using Library.Models.Movie;

namespace BLL.Interfaces
{
    public interface ILikedMovies
    {
        LikedMovieCreate Add(LikedMovieCreate likedMovie);
        List<LikedMovieRead> GetAll();
        LikedMovieRead? GetByUid(Guid uid);
        void Delete(Guid uid);
        List<LikedMovieRead> GetAllByLoggedUser();
        LikedMovieRead GetByUserAndMovie(Guid movieUid);
        List<MovieRead> GetAllByUser(string userUid);
    }
}