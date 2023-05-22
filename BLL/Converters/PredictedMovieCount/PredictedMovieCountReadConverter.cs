using Library.Models.PredictedMovieCount;

namespace BLL.Converters.PredictedMovieCount
{
    public class PredictedMovieCountReadConverter
    {
        public static PredictedMovieCountRead ToBLLModel(DAL.Models.MachineLearning.PredictedMovieCount predictedMovieCountDALModel)
        {
            PredictedMovieCountRead predictedMovieCountRead = new()
            {
                Uid = predictedMovieCountDALModel.PredictedMovieCountGUID,
                UserUid = predictedMovieCountDALModel.UserGUID,
                CreatedAt = predictedMovieCountDALModel.CreatedAt,
                MovieCount = predictedMovieCountDALModel.MovieCount
            };

            return predictedMovieCountRead;
        }

        public static DAL.Models.MachineLearning.PredictedMovieCount ToDALModel(PredictedMovieCountRead predictedMovieCountBLLModel)
        {
            DAL.Models.MachineLearning.PredictedMovieCount predictedMovieCountEntity = new()
            {
                PredictedMovieCountGUID = predictedMovieCountBLLModel.Uid,
                UserGUID = predictedMovieCountBLLModel.UserUid,
                CreatedAt = predictedMovieCountBLLModel.CreatedAt,
                MovieCount = predictedMovieCountBLLModel.MovieCount
            };

            return predictedMovieCountEntity;
        }
    }
}