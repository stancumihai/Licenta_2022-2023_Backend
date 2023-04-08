using Library.Models.LikedMovie;

namespace BLL.Interfaces
{
    public interface ILikedMovies
    {
        LikedMovieCreate Add(LikedMovieCreate likedMovie);
        List<LikedMovieRead> GetAll();
        LikedMovieRead? GetByUid(Guid uid);
        void Delete(Guid uid);
        List<LikedMovieRead> GetAllByLoggedUser(string userGUID);
        LikedMovieRead GetByUserAndMovie(Guid movieUid, string userGUID);
    }
}