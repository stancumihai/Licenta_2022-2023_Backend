using BLL.Converters.Recommendation;
using BLL.Core;
using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces;
using DAL.Models;
using Library.Enums;
using Library.MachineLearningModels;
using Library.Models._UI;
using Library.Models.Recommendation;
using Microsoft.AspNetCore.Identity;

namespace BLL.Implementation
{
    public class RecommendationsBL : BusinessObject, IRecommendations
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RecommendationsBL(DAL.Interfaces.IDALContext dalContext,
            UserManager<ApplicationUser> userManager) : base(dalContext)
        {
            _userManager = userManager;
        }
        private static RecommendationStatus GetRecommendationStatus(Recommendation recommendation)
        {
            if (recommendation.LikedDecisionDate <= recommendation.CreatedAt)
            {
                return RecommendationStatus.NotSeen;
            }

            return recommendation.IsLiked == false ? RecommendationStatus.Disliked : RecommendationStatus.Liked;
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

        public List<RecommendationRead> GetAllByUserAndMonth(string userUid, int year, int month)
        {
            return _dalContext.Recommendations
               .GetAllByUserYearAndMonth(userUid, year, month)
               .Select(seenMovie => RecommendationReadConverter.ToBLLModel(seenMovie))
               .ToList();
        }

        public List<RecommendationRead> GetAllByMonth(int year, int month)
        {
            return _dalContext.Recommendations
               .GetAllByYearAndMonth(year, month)
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
            recommendationDalModel.Movie = existingRecommendation.Movie;
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
                    var recommendationStatus = GetRecommendationStatus(recommendation);
                    switch (recommendationStatus)
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
                    float accuracy = GetAccuracyStrategy3(periodRecommendations);
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

                float accuracy = GetAccuracyStrategy3(monthlyRecommendations);
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

        public static float GetAccuracyStrategy3(List<Recommendation> recommendations)
        {
            List<Recommendation> filteredRecommendations = recommendations
                .Where(r => GetRecommendationStatus(r) != RecommendationStatus.NotSeen)
                .ToList();
            float startAccuracy = filteredRecommendations.Count;
            foreach (Recommendation recommendation in filteredRecommendations)
            {
                RecommendationStatus recommendationStatus = GetRecommendationStatus(recommendation);
                if (recommendationStatus == RecommendationStatus.Liked)
                {
                    continue;
                }
                startAccuracy--;
            }
            return startAccuracy / filteredRecommendations.Count;
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age--;
            }

            return age;
        }

        private string GetMostWatchedGenre(List<Movie> movies)
        {
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            IDictionary<string, int> topMovieGenres = new Dictionary<string, int>();
            foreach (Movie movie in movies)
            {
                string[] currentMovieGenres = movie.Genres.Split(',');

                foreach (string genre in currentMovieGenres)
                {
                    if (topMovieGenres.ContainsKey(genre))
                    {
                        topMovieGenres[genre]++;
                        continue;
                    }
                    topMovieGenres.Add(genre, 1);
                }
            }
            if (topMovieGenres.Count > 0)
            {
                return (from topMovieGenre in topMovieGenres
                        orderby topMovieGenre.Value
                        descending
                        select topMovieGenre.Key).ToList()[0];
            }
            return "";
        }

        private string GetMostWatchedMovie(List<Movie> movies)
        {
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            IDictionary<string, int> topSeenMovies = new Dictionary<string, int>();
            foreach (Movie movie in movies)
            {
                if (topSeenMovies.ContainsKey(movie.Title))
                {
                    topSeenMovies[movie.Title]++;
                    continue;
                }
                topSeenMovies.Add(movie.Title, 1);
            }
            if (topSeenMovies.Count > 0)
            {
                return (from topSeenMovie in topSeenMovies
                        orderby topSeenMovie.Value
                        descending
                        select topSeenMovie.Key)
                        .ToList()[0];
            }
            return "";
        }

        public decimal GetAverageUsersRating(int year, int month)
        {
            List<UserMovieRating> userMovieRatings = _dalContext.UserMovieRatings
                .GetAll()
                .Where(u => u.CreatedAt.Year == year &&
                            u.CreatedAt.Month == month)
                .ToList();
            if (userMovieRatings.Count == 0)
            {
                return 0;
            }
            decimal summedRating = userMovieRatings.Sum(f => f.Rating);
            return summedRating / userMovieRatings.Count;
        }

        public decimal GetAverageUserRating(string userUid, int year, int month)
        {
            List<UserMovieRating> userMovieRatings = _dalContext.UserMovieRatings
                .GetAll()
                .Where(u => u.UserGUID == userUid &&
                            u.CreatedAt.Year == year &&
                            u.CreatedAt.Month == month)
                .ToList();
            if (userMovieRatings.Count == 0)
            {
                return 0;
            }
            decimal summedRating = userMovieRatings.Sum(f => f.Rating);
            return summedRating / userMovieRatings.Count;
        }


        private async Task<List<PredictedMovie>> GetDataByMonth(int year, int month)
        {
            List<PredictedMovie> predictedMovies = new();
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            int numberOfRecommendationsPerMonth = 50;
            List<DAL.Models.MachineLearning.PredictedGenre> predictedGenres = _dalContext.PredictedGenres
                                                                                     .GetAll()
                                                                                     .Where(p => p.CreatedAt.Year == year && p.CreatedAt.Month == month)
                                                                                     .ToList();
            List<Movie> movies = _dalContext.Movies.GetAll();
            decimal averageUsersRating = Math.Round(GetAverageUsersRating(year, month), 2);
            foreach (ApplicationUser user in users)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                if (roles.FirstOrDefault(r => r == "Administrator") != null)
                {
                    continue;
                }
                UserProfile? userProfile = _dalContext.UserProfiles.GetByUserGuid(user.Id);
                decimal averageUserRating = Math.Round(GetAverageUserRating(user.Id.ToString(), year, month), 2);
                if (userProfile == null)
                {
                    continue;
                }
                int age = CalculateAge(userProfile.DateOfBirth);
                List<Movie> seenMovies = _dalContext.SeenMovies
                    .GetAllByUser(user.Id)
                    .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                    .Select(s => s.Movie)
                    .ToList();
                if (seenMovies.Count == 0)
                {
                    continue;
                }
                List<Movie> watchLaterMovies = _dalContext.MovieSubscriptions
                .GetAllByUser(user.Id)
                .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                .Select(s => s.Movie)
                .ToList();
                List<Movie> likedMovies = _dalContext.LikedMovies
                    .GetAllByUser(user.Id)
                    .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                    .Select(s => s.Movie)
                    .ToList();
                List<Movie> collectionMovies = _dalContext.Movies.GetMoviesCollection(user.Id).ToList();
                List<DAL.Models.MachineLearning.PredictedGenre> userPredictedGenres = predictedGenres.Where(p => p.UserGUID == user.Id).ToList();
                string mostWatchedGenre = GetMostWatchedGenre(seenMovies);
                string mostWatchedLaterMovie = GetMostWatchedMovie(watchLaterMovies);
                string mostLikedMovie = GetMostWatchedMovie(likedMovies);
                string mostWatchedMovie = GetMostWatchedMovie(seenMovies);
                for (int j = 0; j < numberOfRecommendationsPerMonth; j++)
                {
                    string predictedGenre = userPredictedGenres[j % userPredictedGenres.Count].Genre;
                    if (predictedGenre == "SciFi")
                    {
                        predictedGenre = "Sci-Fi";
                    }
                    if (predictedGenre == "FilmNoir")
                    {
                        predictedGenre = "Film-Noir";
                    }
                    List<Movie> futurePredictedMovies = movies
                        .Where(m => m.Genres.Split(',').Contains(predictedGenre))
                        .ToList();
                    if (futurePredictedMovies.Count == 0)
                    {
                        futurePredictedMovies = likedMovies;
                    }
                    string futurePredictedMovie = futurePredictedMovies[j % futurePredictedMovies.Count].Title;
                    string watchLaterMovie = "";
                    string collectionMovie = "";
                    string likedMovie = "";
                    if (watchLaterMovies.Count == 0)
                    {
                        watchLaterMovie = seenMovies[j % seenMovies.Count].Title;
                    }
                    else
                    {
                        watchLaterMovie = watchLaterMovies[j % watchLaterMovies.Count].Title;
                    }
                    if (collectionMovies.Count == 0)
                    {
                        collectionMovie = seenMovies[j * 2 % seenMovies.Count].Title;
                    }
                    else
                    {
                        collectionMovie = collectionMovies[j % collectionMovies.Count].Title;
                    }
                    if (likedMovies.Count == 0)
                    {
                        likedMovie = seenMovies[j * 3 % seenMovies.Count].Title;
                    }
                    else
                    {
                        likedMovie = likedMovies[j % likedMovies.Count].Title;
                    }
                    bool hasCollectionMovies = collectionMovies.Count > 0;
                    predictedMovies.Add(new()
                    {
                        UserEmail = user.Email,
                        WatchLaterMovie = watchLaterMovie,
                        LikedMovie = likedMovie,
                        CollectionMovie = collectionMovie,
                        Age = age,
                        City = userProfile.City,
                        MostWatchedGenre = mostWatchedMovie,
                        MostWatchedMovie = mostWatchedGenre,
                        MyAverageRating = averageUserRating,
                        AverageRating = averageUsersRating,
                        PredictedGenre = predictedGenre
                    });
                }
            }
            return predictedMovies;
        }

        public async Task ProcessPredictedMoviesJobAction(int year, int month)
        {
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAll();
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;
            List<PredictedMovie> predictedMovies = await GetDataByMonth(year, month);
            ICSVHandlerService csvHandler = new CSVHandlerService("Files\\Predicting\\test_future_movies_predicted.csv");
            int predictedMoviesCount = predictedMovies.Count;
            int stepSize = 100;
            int maxCurrentSize = 0;
            for (int i = 0; i < predictedMoviesCount; i++)
            {
                try
                {
                    List<PredictedMovie> currentPredictedMovies = predictedMovies.Skip(i * stepSize).Take(stepSize).ToList();
                    csvHandler.WriteCSV(currentPredictedMovies);
                    List<string> currentPredictedData = ScriptEngine.GetPredictedData("predictedMovies", "predict");
                    List<string> currentPredictedDataDecoded = new List<string>();
                    foreach (string currentData in currentPredictedData)
                    {
                        string currentDataDecoded = currentData.Substring(2, currentData.Length - 3);
                        currentPredictedDataDecoded.Add(currentDataDecoded);
                    }
                    int k = 0;
                    for (int j = i * stepSize; j < i * stepSize + currentPredictedMovies.Count; j++)
                    {
                        predictedMovies[j].FuturePredictedMovie = currentPredictedDataDecoded[k];
                        k++;
                    }
                    maxCurrentSize = (i + 1) * stepSize;
                    if (maxCurrentSize > predictedMoviesCount)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }
            csvHandler.WriteCSV(predictedMovies);
            List<List<string>> csvData = csvHandler.ReadCsvFile();
            csvData = csvData.Skip(1).ToList();
            csvHandler.AppendRowsToCsv("Files\\Training\\predictedMovie.csv", csvData);
            List<string> userEmails = csvData.Select(s => s[0]).ToList();
            for (int i = 0; i < userEmails.Count; i++)
            {
                string predictedMovieName = predictedMovies[i].FuturePredictedMovie;

                Movie? movie = _dalContext.Movies.GetByName(predictedMovieName);
                if (movie == null)
                {
                    continue;
                }
                Recommendation recommendation = new()
                {
                    MovieGUID = _dalContext.Movies.GetByName(predictedMovieName)!.MovieGUID,
                    UserGUID = _dalContext.Users.GetByEmail(userEmails[i])!.Id,
                    CreatedAt = new DateTime(year, month, 1)
                };
                _dalContext.Recommendations.Add(recommendation);
            }
            ScriptEngine.TrainToPredictModel("predictedMovies", "training", currentAlgorithmName);
        }
    }
}