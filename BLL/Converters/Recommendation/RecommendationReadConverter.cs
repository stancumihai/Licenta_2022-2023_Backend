using Library.Models.Recommendation;

namespace BLL.Converters.Recommendation
{
    public class RecommendationReadConverter
    {
        public static RecommendationRead ToBLLModel(DAL.Models.Recommendation recommendationDALModel)
        {
            RecommendationRead recommendationRead = new()
            {
                Uid = recommendationDALModel.RecommendationGUID,
                MovieUid = recommendationDALModel.MovieGUID,
                UserUid = recommendationDALModel.UserGUID,
                CreatedAt = recommendationDALModel.CreatedAt,
                LikedDecisionDate = recommendationDALModel.LikedDecisionDate,
                IsLiked = recommendationDALModel.IsLiked,
            };

            return recommendationRead;
        }

        public static DAL.Models.Recommendation ToDALModel(RecommendationRead recommendationBLLModel)
        {
            DAL.Models.Recommendation recommendationEntity = new()
            {
                RecommendationGUID = recommendationBLLModel.Uid,
                MovieGUID = recommendationBLLModel.MovieUid,
                UserGUID = recommendationBLLModel.UserUid,
                CreatedAt = recommendationBLLModel.CreatedAt,
                LikedDecisionDate = recommendationBLLModel.LikedDecisionDate,
                IsLiked = recommendationBLLModel.IsLiked,
            };

            return recommendationEntity;
        }
    }
}