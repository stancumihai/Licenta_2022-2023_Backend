using Library.Models.PredictedMovieCount;

namespace BLL.Interfaces.MachineLearning
{
    public interface IPredictedMoviesCount
    {
        PredictedMovieCountCreate Add(PredictedMovieCountCreate predictedMovieCount);
        List<PredictedMovieCountRead> GetAll();
        List<PredictedMovieCountRead> GetAllByDate(int year, int month);
        Task<List<Library.MachineLearningModels.PredictedMovieCount>> GetLastMonthData();
    }
}