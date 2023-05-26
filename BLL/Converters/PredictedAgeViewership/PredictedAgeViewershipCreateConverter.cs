using Library.Models.PredictedAgeViewership;

namespace BLL.Converters.PredictedAgeViewership
{
    public class PredictedAgeViewershipCreateConverter
    {
        public static PredictedAgeViewershipCreate ToBLLModel(DAL.Models.MachineLearning.PredictedAgeViewership predictedAgeViewershipDALModel)
        {
            PredictedAgeViewershipCreate predictedAgeViewershipCreate = new()
            {
                Age = predictedAgeViewershipDALModel.Age,
                CreatedAt = predictedAgeViewershipDALModel.CreatedAt,
                MovieCount = predictedAgeViewershipDALModel.MovieCount
            };

            return predictedAgeViewershipCreate;
        }

        public static DAL.Models.MachineLearning.PredictedAgeViewership ToDALModel(PredictedAgeViewershipCreate predictedAgeViewershipBLLModel)
        {
            DAL.Models.MachineLearning.PredictedAgeViewership predictedAgeViewershipEntity = new()
            {
                Age = predictedAgeViewershipBLLModel.Age,
                CreatedAt = predictedAgeViewershipBLLModel.CreatedAt,
                MovieCount = predictedAgeViewershipBLLModel.MovieCount
            };

            return predictedAgeViewershipEntity;
        }
    }
}