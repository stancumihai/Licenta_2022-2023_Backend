using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRecommendations
    {
        Recommendation Add(Recommendation recommendation);
        List<Recommendation> GetAll();
        Recommendation? GetByGuid(Guid guid);
        Recommendation Update(Recommendation recommendation);
        List<Recommendation> GetAllByUser(string userUid);
        List<Recommendation> GetAllByUserAndMonth(string userUid, DateTime date);
    }
}