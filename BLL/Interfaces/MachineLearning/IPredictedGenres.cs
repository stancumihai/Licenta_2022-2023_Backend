using Library.Models.PredictedGenre;

namespace BLL.Interfaces.MachineLearning
{
    public interface IPredictedGenres
    {
        PredictedGenreCreate Add(PredictedGenreCreate predictedGenre);
        List<PredictedGenreRead> GetAll();
        List<PredictedGenreRead> GetAllByDate(int year, int month);
        Task<List<Library.MachineLearningModels.PredictedGenre>> GetLastMonthData();
    }
}