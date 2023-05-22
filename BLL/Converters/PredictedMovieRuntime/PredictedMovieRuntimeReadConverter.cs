using Library.Models.PredictedMovieRuntime;

namespace BLL.Converters.PredictedMovieRuntime
{
    public class PredictedMovieRuntimeReadConverter
    {
        public static PredictedMovieRuntimeRead ToBLLModel(DAL.Models.MachineLearning.PredictedMovieRuntime predictedMovieRuntimeDALModel)
        {
            PredictedMovieRuntimeRead predictedMovieRuntimeRead = new()
            {
                Uid = predictedMovieRuntimeDALModel.PredictedMovieRuntimeGUID,
                UserUid = predictedMovieRuntimeDALModel.UserGUID,
                CreatedAt = predictedMovieRuntimeDALModel.CreatedAt,
                MovieRuntime = predictedMovieRuntimeDALModel.MovieRuntime
            };

            return predictedMovieRuntimeRead;
        }

        public static DAL.Models.MachineLearning.PredictedMovieRuntime ToDALModel(PredictedMovieRuntimeRead predictedMovieRuntimeBLLModel)
        {
            DAL.Models.MachineLearning.PredictedMovieRuntime predictedMovieRuntimeEntity = new()
            {
                PredictedMovieRuntimeGUID = predictedMovieRuntimeBLLModel.Uid,
                UserGUID = predictedMovieRuntimeBLLModel.UserUid,
                CreatedAt = predictedMovieRuntimeBLLModel.CreatedAt,
                MovieRuntime = predictedMovieRuntimeBLLModel.MovieRuntime
            };

            return predictedMovieRuntimeEntity;
        }
    }
}