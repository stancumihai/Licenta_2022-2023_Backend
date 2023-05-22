using Library.Models.PredictedMovieRuntime;

namespace BLL.Converters.PredictedMovieRuntime
{
    public class PredictedMovieRuntimeCreateConverter
    {
        public static PredictedMovieRuntimeCreate ToBLLModel(DAL.Models.MachineLearning.PredictedMovieRuntime predictedMovieRuntimeDALModel)
        {
            PredictedMovieRuntimeCreate predictedMovieRuntimeCreate = new()
            {
                UserUid = predictedMovieRuntimeDALModel.UserGUID,
                CreatedAt = predictedMovieRuntimeDALModel.CreatedAt,
                MovieRuntime = predictedMovieRuntimeDALModel.MovieRuntime
            };

            return predictedMovieRuntimeCreate;
        }

        public static DAL.Models.MachineLearning.PredictedMovieRuntime ToDALModel(PredictedMovieRuntimeCreate predictedMovieRuntimeBLLModel)
        {
            DAL.Models.MachineLearning.PredictedMovieRuntime predictedMovieRuntimeEntity = new()
            {
                UserGUID = predictedMovieRuntimeBLLModel.UserUid,
                CreatedAt = predictedMovieRuntimeBLLModel.CreatedAt,
                MovieRuntime = predictedMovieRuntimeBLLModel.MovieRuntime
            };

            return predictedMovieRuntimeEntity;
        }
    }
}