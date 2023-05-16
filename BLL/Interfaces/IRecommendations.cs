using Library.Models;
using Library.Models.Recommendation;

namespace BLL.Interfaces
{
    public interface IRecommendations
    {
        RecommendationCreate Add(RecommendationCreate recommendation);
        List<RecommendationRead> GetAll();
        RecommendationRead Update(RecommendationUpdate recommendation);
        List<RecommendationRead> GetAllByUser(string userUid);
        List<RecommendationRead> GetAllByUserAndMonth(string userUid, DateTime date);
        float GetAccuracyByUser(string userUid);
        public List<AccuracyPeriodModel> GetAccuracyPerMonths();
    }
}