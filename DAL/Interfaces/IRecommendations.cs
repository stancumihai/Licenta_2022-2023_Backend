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
        List<Recommendation> GetAllByUserYearAndMonth(string userUid, int year, int month);
        List<Recommendation> GetAllByYearAndMonth(int year, int month);
    }
}