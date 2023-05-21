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
               .GetAllByUserYearAndMonth(userUid, date)
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
            return (float)startAccuracy / recommendations.Count;
        }

        public List<MonthlyRecommendationStatusModel> GetMonthlyRecommendationStatuses(int year, int month, string algorithmName)
        {
            List<Recommendation> recommendations = _dalContext.Recommendations.GetAllByYearAndMonth(year, month);
            int likedCount = 0;
            int dislikeCount = 0;
            int notSeenCount = 0;
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAllByAlgorithmName(algorithmName);
            foreach (Recommendation recommendation in recommendations)
            {
                if (algorithmChanges.Any(a => a.StartDate.Year >= year && a.EndDate.Year <= year &&
                                              a.StartDate.Month >= month && a.StartDate.Month <= month))
                {
                    switch (GetRecommendationStatus(recommendation))
                    {
                        case RecommendationStatus.Liked:
                            {
                                likedCount++;
                                break;
                            }
                        case RecommendationStatus.Disliked:
                            {
                                dislikeCount++;
                                break;
                            }
                        default:
                            {
                                notSeenCount++;
                                break;
                            }
                    }
                }

            }
            List<MonthlyRecommendationStatusModel> monthlyRecommendationStatusModels = new();
            monthlyRecommendationStatusModels.Add(new MonthlyRecommendationStatusModel
            {
                RecommendationOutcome = "Liked",
                Count = likedCount
            });
            monthlyRecommendationStatusModels.Add(new MonthlyRecommendationStatusModel
            {
                RecommendationOutcome = "Disliked",
                Count = dislikeCount
            });
            monthlyRecommendationStatusModels.Add(new MonthlyRecommendationStatusModel
            {
                RecommendationOutcome = "NotSeen",
                Count = notSeenCount
            });
            monthlyRecommendationStatusModels.Add(new MonthlyRecommendationStatusModel
            {
                RecommendationOutcome = "All",
                Count = recommendations.Count
            });
            return monthlyRecommendationStatusModels;
        }


        public List<AccuracyPeriodModel> GetAccuracyPerMonthsByAlgorithm(string algorithmName)
        {
            List<Recommendation> recommendations = _dalContext.Recommendations.GetAll();
            recommendations = (from recommendation in recommendations
                               orderby recommendation.CreatedAt.Year, recommendation.CreatedAt.Month, recommendation.CreatedAt.Day
                               ascending
                               select recommendation)
                               .ToList();
            List<AccuracyPeriodModel> accuracyPeriods = new();
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAllByAlgorithmName(algorithmName);
            foreach (Recommendation recommendation in recommendations)
            {
                int month = recommendation.CreatedAt.Month;
                int year = recommendation.CreatedAt.Year;
                if (algorithmChanges.Any(a => a.StartDate.Year >= year && a.EndDate.Year <= year &&
                                              a.StartDate.Month >= month && a.StartDate.Month <= month))
                {
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
                        Month = month,
                        Year = year,
                        Accuracy = accuracy
                    });
                }
            }
            return accuracyPeriods;
        }

        public List<SummaryMonthlyStatistics> GetMonthlySummaries()
        {
            List<Recommendation> recommendations = _dalContext.Recommendations.GetAll();
            recommendations = (from recommendation in recommendations
                               orderby recommendation.CreatedAt.Year, recommendation.CreatedAt.Month, recommendation.CreatedAt.Day
                               ascending
                               select recommendation)
                              .ToList();
            List<SummaryMonthlyStatistics> summaryMonthlyStatistics = new();
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAll();
            algorithmChanges = (from algorithmChange in algorithmChanges
                                orderby algorithmChange.StartDate
                               ascending
                               select algorithmChange)
                              .ToList();
            foreach (Recommendation recommendation in recommendations)
            {
                int year = recommendation.CreatedAt.Year;
                int month = recommendation.CreatedAt.Month;
                if (summaryMonthlyStatistics.Any(a => a.Year == year && a.Month == month))
                {
                    continue;
                }
                List<Recommendation> monthlyRecommendations = recommendations
                    .Where(r => r.CreatedAt.Year == year && r.CreatedAt.Month == month)
                    .ToList();

                float accuracy = GetAccuracy_Strategy1(monthlyRecommendations);
                AlgorithmChange? algorithmChange = algorithmChanges
                    .FirstOrDefault(a => a.StartDate <= recommendation.CreatedAt && a.EndDate >= recommendation.CreatedAt);
                summaryMonthlyStatistics.Add(new SummaryMonthlyStatistics
                {
                    Month = month,
                    Year = year,
                    Accuracy = accuracy,
                    Algorithm = algorithmChange.AlgorithmName,
                    Count = monthlyRecommendations.Count
                });
            }
            return summaryMonthlyStatistics;
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