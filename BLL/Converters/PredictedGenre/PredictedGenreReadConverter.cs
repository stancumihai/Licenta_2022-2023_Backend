using Library.Models.PredictedGenre;

namespace BLL.Converters.PredictedGenre
{
    public class PredictedGenreReadConverter
    {
        public static PredictedGenreRead ToBLLModel(DAL.Models.MachineLearning.PredictedGenre predictedGenreDALModel)
        {
            PredictedGenreRead predictedGenreRead = new()
            {
                Uid = predictedGenreDALModel.PredictedGenreGUID,
                UserUid = predictedGenreDALModel.UserGUID,
                CreatedAt = predictedGenreDALModel.CreatedAt,
                Genre = predictedGenreDALModel.Genre
            };

            return predictedGenreRead;
        }

        public static DAL.Models.MachineLearning.PredictedGenre ToDALModel(PredictedGenreRead predictedGenreBLLModel)
        {
            DAL.Models.MachineLearning.PredictedGenre predictedGenreEntity = new()
            {
                PredictedGenreGUID = predictedGenreBLLModel.Uid ,
                UserGUID = predictedGenreBLLModel.UserUid,
                CreatedAt = predictedGenreBLLModel.CreatedAt,
                Genre = predictedGenreBLLModel.Genre
            };

            return predictedGenreEntity;
        }
    }
}