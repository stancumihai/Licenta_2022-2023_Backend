using Library.Models.PredictedMovieRuntime;

namespace BLL.Interfaces.MachineLearning
{
    public interface IPredictedMoviesRuntime
    {
        PredictedMovieRuntimeCreate Add(PredictedMovieRuntimeCreate predictedMovieRuntime);
        List<PredictedMovieRuntimeRead> GetAll();
        List<Library.Models._UI.MachineLearning.PredictedMovieRuntime> GetEachMonthByUser(string userUid);
        List<Library.Models._UI.MachineLearning.PredictedMovieRuntime> GetEachMonth();
        Task ProcessPredictedMovieRuntimeJobAction(int year, int month);
    }
}