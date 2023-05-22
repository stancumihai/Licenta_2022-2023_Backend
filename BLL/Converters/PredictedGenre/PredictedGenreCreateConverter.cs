using Library.Models.PredictedGenre;

namespace BLL.Converters.PredictedGenre
{
    public class PredictedGenreCreateConverter
    {
        public static PredictedGenreCreate ToBLLModel(DAL.Models.MachineLearning.PredictedGenre predictedGenreDALModel)
        {
            PredictedGenreCreate predictedGenreCreate = new()
            {
                UserUid = predictedGenreDALModel.UserGUID,
                CreatedAt = predictedGenreDALModel.CreatedAt,
                Genre = predictedGenreDALModel.Genre
            };

            return predictedGenreCreate;
        }

        public static DAL.Models.MachineLearning.PredictedGenre ToDALModel(PredictedGenreCreate predictedGenreBLLModel)
        {
            DAL.Models.MachineLearning.PredictedGenre predictedGenreEntity = new()
            {
                UserGUID = predictedGenreBLLModel.UserUid,
                CreatedAt = predictedGenreBLLModel.CreatedAt,
                Genre = predictedGenreBLLModel.Genre
            };

            return predictedGenreEntity;
        }
    }
}