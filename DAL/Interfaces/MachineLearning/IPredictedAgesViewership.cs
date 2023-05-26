using DAL.Models.MachineLearning;

namespace DAL.Interfaces.MachineLearning
{
    public interface IPredictedAgesViewership
    {
        PredictedAgeViewership Add(PredictedAgeViewership predictedAgeViewership);
        List<PredictedAgeViewership> GetAll();
    }
}