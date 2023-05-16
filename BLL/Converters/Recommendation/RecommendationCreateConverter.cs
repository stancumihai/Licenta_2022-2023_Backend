using Library.Models.Recommendation;

namespace BLL.Converters.Recommendation
{
    public class RecommendationCreateConverter
    {
        public static RecommendationCreate ToBLLModel(DAL.Models.Recommendation recommendationDALModel)
        {
            RecommendationCreate recommendationCreate = new()
            {
                MovieUid = recommendationDALModel.MovieGUID,
                UserUid = recommendationDALModel.UserGUID,
                CreatedAt = recommendationDALModel.CreatedAt,
                LikedDecisionDate = recommendationDALModel.LikedDecisionDate,
                IsLiked = recommendationDALModel.IsLiked,
            };

            return recommendationCreate;
        }

        public static DAL.Models.Recommendation ToDALModel(RecommendationCreate recommendationBLLModel)
        {
            DAL.Models.Recommendation recommendationEntity = new()
            {
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