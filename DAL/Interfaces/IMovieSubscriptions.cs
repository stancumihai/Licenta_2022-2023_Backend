using DAL.Models;

namespace DAL.Interfaces
{
    public interface IMovieSubscriptions
    {
        MovieSubscription Add(MovieSubscription movieSubscription);
        List<MovieSubscription> GetAll();
        MovieSubscription? GetByUid(Guid uid);
        MovieSubscription Delete(Guid uid);
        MovieSubscription GetByUserAndMovie(Guid movieUid, string userGUID);
        List<MovieSubscription> GetAllByUser(string userUid);
    }
}