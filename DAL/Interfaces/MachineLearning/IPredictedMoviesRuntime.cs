using DAL.Models.MachineLearning;

namespace DAL.Interfaces.MachineLearning
{
    public interface IPredictedMoviesRuntime
    {
        PredictedMovieRuntime Add(PredictedMovieRuntime predictedMovieRuntime);
        List<PredictedMovieRuntime> GetAll();
        List<PredictedMovieRuntime> GetAllByDate(int year, int month);
    }
}