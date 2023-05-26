using Library.Models.PredictedMovieCount;

namespace BLL.Interfaces.MachineLearning
{
    public interface IPredictedMoviesCount
    {
        PredictedMovieCountCreate Add(PredictedMovieCountCreate predictedMovieCount);
        List<PredictedMovieCountRead> GetAll();
        List<Library.Models._UI.MachineLearning.PredictedMovieCount> GetEachMonthByUser(string userUid);
        List<Library.Models._UI.MachineLearning.PredictedMovieCount> GetEachMonth();
        Task ProcessPredictedMovieCountJobAction(int year, int month);
    }
}