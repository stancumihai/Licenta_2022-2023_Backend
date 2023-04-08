using DAL.Models;

namespace DAL.Interfaces
{
    public interface ILikedMovies
    {
        LikedMovie Add(LikedMovie likedMovie);
        List<LikedMovie> GetAll();
        LikedMovie? GetByUid(Guid uid);
        void Delete(Guid uid);
        List<LikedMovie> GetAllByLoggedUser(string userGUID);
        LikedMovie GetByUserAndMovie(Guid movieUid, string userGUID);
    }
}