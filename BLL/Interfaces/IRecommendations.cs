using Library.Models._UI;
using Library.Models.Recommendation;

namespace BLL.Interfaces
{
    public interface IRecommendations
    {
        RecommendationCreate Add(RecommendationCreate recommendation);
        List<RecommendationRead> GetAll();
        RecommendationRead Update(RecommendationUpdate recommendation);
        List<RecommendationRead> GetAllByUser(string userUid);
        List<RecommendationRead> GetAllByUserAndMonth(string userUid, int year, int month);
        List<RecommendationRead> GetAllByMonth(int year, int month);
        float GetAccuracyByUser(string userUid);
        List<AccuracyPeriodModel> GetAccuracyPerMonthsByAlgorithm(string algorithmName);
        List<MonthlyRecommendationStatusModel> GetMonthlyRecommendationStatuses(int year, int month, string algorithmName);
        List<SummaryMonthlyStatistics> GetMonthlySummaries();
        Task ProcessPredictedMoviesJobAction(int year, int month);
    }
}