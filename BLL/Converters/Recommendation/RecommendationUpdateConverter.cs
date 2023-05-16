using Library.Models.Recommendation;

namespace BLL.Converters.Recommendation
{
    public class RecommendationUpdateConverter
    {
        public static RecommendationUpdate ToBLLModel(DAL.Models.Recommendation recommendationDALModel)
        {
            RecommendationUpdate recommendationRead = new()
            {
                Uid = recommendationDALModel.RecommendationGUID,
                LikedDecisionDate = recommendationDALModel.LikedDecisionDate,
                IsLiked = recommendationDALModel.IsLiked,
            };

            return recommendationRead;
        }

        public static DAL.Models.Recommendation ToDALModel(RecommendationUpdate recommendationBLLModel)
        {
            DAL.Models.Recommendation recommendationEntity = new()
            {
                RecommendationGUID = recommendationBLLModel.Uid,
                LikedDecisionDate = recommendationBLLModel.LikedDecisionDate,
                IsLiked = recommendationBLLModel.IsLiked,
            };

            return recommendationEntity;
        }
    }
}