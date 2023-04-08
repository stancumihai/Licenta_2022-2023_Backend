using DAL.Models;

namespace DAL.Interfaces
{
    public interface ISeenMovies
    {
        SeenMovie Add(SeenMovie movieSubscription);
        List<SeenMovie> GetAll();
        SeenMovie? GetByUid(Guid uid);
        SeenMovie Delete(Guid uid);
        SeenMovie GetByUserAndMovie(Guid movieUid, string userGUID);
    }
}