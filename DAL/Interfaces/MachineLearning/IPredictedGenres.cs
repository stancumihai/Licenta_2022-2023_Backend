using DAL.Models.MachineLearning;

namespace DAL.Interfaces.MachineLearning
{
    public interface IPredictedGenres
    {
        PredictedGenre Add(PredictedGenre predictedGenre);
        List<PredictedGenre> GetAll();
        List<PredictedGenre> GetAllByDate(int year, int month);
    }
}