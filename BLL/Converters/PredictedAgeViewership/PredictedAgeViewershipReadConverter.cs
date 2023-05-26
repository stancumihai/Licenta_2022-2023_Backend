using Library.Models.PredictedAgeViewership;

namespace BLL.Converters.PredictedAgeViewership
{
    public class PredictedAgeViewershipReadConverter
    {
        public static PredictedAgeViewershipRead ToBLLModel(DAL.Models.MachineLearning.PredictedAgeViewership predictedAgeViewershipDALModel)
        {
            PredictedAgeViewershipRead predictedAgeViewershipRead = new()
            {
                Uid = predictedAgeViewershipDALModel.PredictedAgeViewershipGUID,
                Age = predictedAgeViewershipDALModel.Age,
                CreatedAt = predictedAgeViewershipDALModel.CreatedAt,
                MovieCount = predictedAgeViewershipDALModel.MovieCount
            };

            return predictedAgeViewershipRead;
        }

        public static DAL.Models.MachineLearning.PredictedAgeViewership ToDALModel(PredictedAgeViewershipRead predictedAgeViewershipBLLModel)
        {
            DAL.Models.MachineLearning.PredictedAgeViewership predictedAgeViewershipEntity = new()
            {
                PredictedAgeViewershipGUID = predictedAgeViewershipBLLModel.Uid,
                Age = predictedAgeViewershipBLLModel.Age,
                CreatedAt = predictedAgeViewershipBLLModel.CreatedAt,
                MovieCount = predictedAgeViewershipBLLModel.MovieCount
            };

            return predictedAgeViewershipEntity;
        }
    }
}