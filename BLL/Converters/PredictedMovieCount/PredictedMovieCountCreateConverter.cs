using Library.Models.PredictedMovieCount;

namespace BLL.Converters.PredictedMovieCount
{
    public class PredictedMovieCountCreateConverter
    {
        public static PredictedMovieCountCreate ToBLLModel(DAL.Models.MachineLearning.PredictedMovieCount predictedMovieCountDALModel)
        {
            PredictedMovieCountCreate predictedMovieCountCreate = new()
            {
                UserUid = predictedMovieCountDALModel.UserGUID,
                CreatedAt = predictedMovieCountDALModel.CreatedAt,
                MovieCount = predictedMovieCountDALModel.MovieCount
            };

            return predictedMovieCountCreate;
        }

        public static DAL.Models.MachineLearning.PredictedMovieCount ToDALModel(PredictedMovieCountCreate predictedMovieCountBLLModel)
        {
            DAL.Models.MachineLearning.PredictedMovieCount predictedMovieCountEntity = new()
            {
                UserGUID = predictedMovieCountBLLModel.UserUid,
                CreatedAt = predictedMovieCountBLLModel.CreatedAt,
                MovieCount = predictedMovieCountBLLModel.MovieCount
            };

            return predictedMovieCountEntity;
        }
    }
}