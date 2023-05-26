using Library.Models.PredictedGenre;

namespace BLL.Interfaces.MachineLearning
{
    public interface IPredictedGenres
    {
        PredictedGenreCreate Add(PredictedGenreCreate predictedGenre);
        List<PredictedGenreRead> GetAll();
        List<Library.Models._UI.MachineLearning.PredictedGenre> GetEachMonthByUser(string userUid);
        List<Library.Models._UI.MachineLearning.PredictedGenre> GetEachMonth();
        Task ProcessPredictedGenreJobAction(int year, int month);
    }
}