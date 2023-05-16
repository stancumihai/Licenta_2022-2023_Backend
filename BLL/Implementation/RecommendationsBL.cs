using BLL.Converters.Recommendation;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Enums;
using Library.Models;
using Library.Models.Recommendation;

namespace BLL.Implementation
{
    public class RecommendationsBL : BusinessObject, IRecommendations
    {
        private static RecommendationStatus GetRecommendationStatus(Recommendation recommendation)
        {
            if (recommendation.LikedDecisionDate == recommendation.CreatedAt)
            {
                return RecommendationStatus.NotSeen;
            }

            return recommendation.IsLiked == false ? RecommendationStatus.Disliked : RecommendationStatus.Liked;
        }

        public RecommendationsBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public RecommendationCreate Add(RecommendationCreate recommendation)
        {
            Recommendation addedRecommendation = RecommendationCreateConverter.ToDALModel(recommendation);
            if (addedRecommendation == null)
            {
                return null;
            }
            return RecommendationCreateConverter.ToBLLModel(_dalContext.Recommendations.Add(addedRecommendation));
        }

        public List<RecommendationRead> GetAll()
        {
            return _dalContext.Recommendations
              .GetAll()
              .Select(seenMovie => RecommendationReadConverter.ToBLLModel(seenMovie))
              .ToList();
        }

        public List<RecommendationRead> GetAllByUser(string userUid)
        {
            return _dalContext.Recommendations
               .GetAllByUser(userUid)
               .Select(seenMovie => RecommendationReadConverter.ToBLLModel(seenMovie))
               .ToList();
        }

        public List<RecommendationRead> GetAllByUserAndMonth(string userUid, DateTime date)
        {
            return _dalContext.Recommendations
               .GetAllByUserAndMonth(userUid, date)
               .Select(seenMovie => RecommendationReadConverter.ToBLLModel(seenMovie))
               .ToList();
        }

        public RecommendationRead Update(RecommendationUpdate recommendation)
        {
            Recommendation? existingRecommendation = _dalContext.Recommendations.GetByGuid(recommendation.Uid);
            if (existingRecommendation == null)
            {
                return null;
            }
            Recommendation recommendationDalModel = RecommendationUpdateConverter.ToDALModel(recommendation);
            recommendationDalModel.MovieGUID = existingRecommendation.MovieGUID;
            recommendationDalModel.UserGUID = existingRecommendation.UserGUID;
            recommendationDalModel.CreatedAt = existingRecommendation.CreatedAt;
            _dalContext.Recommendations.Update(recommendationDalModel);
            return RecommendationReadConverter.ToBLLModel(recommendationDalModel);
        }

        public float GetAccuracyByUser(string userUid)
        {
            List<Recommendation> recommendations = _dalContext.Recommendations.GetAllByUser(userUid);
            int startAccuracy = recommendations.Count;
            foreach (Recommendation recommendation in recommendations)
            {
                RecommendationStatus recommendationStatus = GetRecommendationStatus(recommendation);
                if (recommendationStatus == RecommendationStatus.Liked || recommendationStatus == RecommendationStatus.NotSeen)
                {
                    continue;
                }
                startAccuracy--;
            }
            return startAccuracy / recommendations.Count;
        }


        public float GetAccuracy_Strategy1(List<Recommendation> recommendations)
        {
            int startAccuracy = recommendations.Count;
            foreach (Recommendation recommendation in recommendations)
            {
                RecommendationStatus recommendationStatus = GetRecommendationStatus(recommendation);
                if (recommendationStatus == RecommendationStatus.Liked || recommendationStatus == RecommendationStatus.NotSeen)
                {
                    continue;
                }
                startAccuracy--;
            }
            return (float) startAccuracy / recommendations.Count;
        }

        public void GetRecommendationsByMonthAndYear(List<Recommendation> recommendations, int month, int year)
        {

        }

        public List<AccuracyPeriodModel> GetAccuracyPerMonths()
        {
            List<Recommendation> recommendations = _dalContext.Recommendations.GetAll();
            List<AccuracyPeriodModel> accuracyPeriods = new List<AccuracyPeriodModel>();
            recommendations = (from recommendation in recommendations
                               orderby recommendation.CreatedAt.Year, recommendation.CreatedAt.Month, recommendation.CreatedAt.Day
                                ascending
                               select recommendation).ToList();
            foreach (Recommendation recommendation in recommendations)
            {
                int month = recommendation.CreatedAt.Month;
                int year = recommendation.CreatedAt.Year;
                if (accuracyPeriods.FirstOrDefault(a => a.Year == year && a.Month == month) != null)
                {
                    continue;
                }
                List<Recommendation> periodRecommendations = recommendations
                    .Where(r => r.CreatedAt.Year == year && r.CreatedAt.Month == month)
                    .ToList();
                float accuracy = GetAccuracy_Strategy1(periodRecommendations);
                accuracyPeriods.Add(new AccuracyPeriodModel
                {
                    Year = year,
                    Month = month,
                    Accuracy = accuracy
                });
            }
            return accuracyPeriods;
        }

        //public float GetAccuracy_Strategy2(List<Recommendation> recommendations)
        //{
        //    int startAccuracy = recommendations.Count;
        //    foreach (Recommendation recommendation in recommendations)
        //    {
        //        RecommendationStatus recommendationStatus = GetRecommendationStatus(recommendation);
        //        if (recommendationStatus == RecommendationStatus.Liked)
        //        {
        //            continue;
        //        }
        //        startAccuracy--;
        //    }
        //    return startAccuracy / recommendations.Count;
        //}

        //public float GetAccuracy_Strategy3(List<Recommendation> recommendations)
        //{
        //    List<Recommendation> recommendations = recommendations
        //        .Where(r => GetRecommendationStatus(r) != RecommendationStatus.NotSeen)
        //        .ToList();
        //    int startAccuracy = recommendations.Count;
        //    foreach (Recommendation recommendation in recommendations)
        //    {
        //        RecommendationStatus recommendationStatus = GetRecommendationStatus(recommendation);
        //        if (recommendationStatus == RecommendationStatus.Liked)
        //        {
        //            continue;
        //        }
        //        startAccuracy--;
        //    }
        //    return startAccuracy / recommendations.Count;
        //}
    }
}