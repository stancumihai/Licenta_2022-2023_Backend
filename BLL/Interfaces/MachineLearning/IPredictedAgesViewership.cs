using Library.Models._UI;
using Library.Models.PredictedAgeViewership;

namespace BLL.Interfaces.MachineLearning
{
    public interface IPredictedAgesViewership
    {
        PredictedAgeViewershipCreate Add(PredictedAgeViewershipCreate predictedAgeViewership);
        List<PredictedAgeViewershipRead> GetAll();
        void ProcessPredictedAgeViwershipAction(int year, int month);
        List<AgeViewershipModel> GetByMonth(int year, int month);
    }
}