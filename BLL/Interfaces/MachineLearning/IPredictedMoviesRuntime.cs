using Library.Models.PredictedMovieRuntime;

namespace BLL.Interfaces.MachineLearning
{
    public interface IPredictedMoviesRuntime
    {
        PredictedMovieRuntimeCreate Add(PredictedMovieRuntimeCreate predictedMovieRuntime);
        List<PredictedMovieRuntimeRead> GetAll();
        List<PredictedMovieRuntimeRead> GetAllByDate(int year, int month);
        Task<List<Library.MachineLearningModels.PredictedMovieRuntime>> GetLastMonthData();
    }
}