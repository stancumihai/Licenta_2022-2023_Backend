using DAL.Models.MachineLearning;

namespace DAL.Interfaces.MachineLearning
{
    public interface IPredictedMoviesCount
    {
        PredictedMovieCount Add(PredictedMovieCount predictedMovieCount);
        List<PredictedMovieCount> GetAll();
        List<PredictedMovieCount> GetAllByDate(int year, int month);
    }
}