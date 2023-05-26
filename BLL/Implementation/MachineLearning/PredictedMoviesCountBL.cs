using BLL.Converters.PredictedMovieCount;
using BLL.Converters.User;
using BLL.Core;
using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces.MachineLearning;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.MachineLearning;
using Library.Enums;
using Library.Models.PredictedMovieCount;
using Library.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BLL.Implementation.MachineLearning
{
    public class PredictedMoviesCountBL : BusinessObject, IPredictedMoviesCount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public PredictedMoviesCountBL(IDALContext dalContext,
            UserManager<ApplicationUser> userManager) : base(dalContext)
        {
            _userManager = userManager;
        }

        public PredictedMovieCountCreate Add(PredictedMovieCountCreate predictedMovieCount)
        {
            PredictedMovieCount addedPredictedMovieCount = _dalContext.PredictedMoviesCount.Add(PredictedMovieCountCreateConverter.ToDALModel(predictedMovieCount));
            if (addedPredictedMovieCount == null)
            {
                return null;
            }
            return PredictedMovieCountCreateConverter.ToBLLModel(addedPredictedMovieCount);
        }

        public List<PredictedMovieCountRead> GetAll()
        {
            return _dalContext.PredictedMoviesCount
                .GetAll()
                .Select(p => PredictedMovieCountReadConverter.ToBLLModel(p))
                .ToList();
        }

        private static float GetAverageMovieSubscriptions(List<UserRead> users, List<MovieSubscription> movieSubscriptions)
        {
            float movieCount = 0.0f;
            int usersWithSeenMovies = 0;
            foreach (UserRead user in users)
            {
                float userMovieCount = movieSubscriptions
                    .Where(s => s.UserGUID == user.Uid.ToString())
                    .ToList()
                    .Count;
                if (userMovieCount > 0)
                {
                    movieCount += userMovieCount;
                    usersWithSeenMovies++;
                }
            }
            return (float)movieCount / usersWithSeenMovies;
        }


        private static float GetAverageMovieCount(List<UserRead> users, List<SeenMovie> seenMovies)
        {
            float movieCount = 0.0f;
            int usersWithSeenMovies = 0;
            foreach (UserRead user in users)
            {
                float userMovieCount = seenMovies
                    .Where(s => s.UserGUID == user.Uid.ToString())
                    .ToList()
                    .Count;
                if (userMovieCount > 0)
                {
                    movieCount += userMovieCount;
                    usersWithSeenMovies++;
                }
            }
            return (float)movieCount / usersWithSeenMovies;
        }

        private static float GetAverageMovieClicks(List<UserRead> users, List<UserMovieSearch> userMovieSearches)
        {
            float searchesCount = 0.0f;
            int userWithSearches = 0;
            foreach (UserRead user in users)
            {
                float userSearchesCount = userMovieSearches
                    .Where(u => u.UserGUID == user.Uid.ToString())
                    .ToList()
                    .Count;
                if (userSearchesCount > 0)
                {
                    searchesCount += userSearchesCount;
                    userWithSearches++;
                }
            }
            return (float)searchesCount / userWithSearches;
        }

        private async Task<List<Library.MachineLearningModels.PredictedMovieCount>> GetDataByMonth(int year, int month)
        {
            List<UserRead> users = _dalContext.Users.GetAll()
                .Select(u => UserReadConverter.ToBLLModel(u))
                .ToList();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies.GetAll()
                .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                .ToList();
            List<MovieSubscription> movieSubscriptions = _dalContext.MovieSubscriptions
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            List<LikedMovie> likedMovies = _dalContext.LikedMovies.GetAll()
              .Where(s => s.CreatedAt.Year == year &&
                          s.CreatedAt.Month == month)
              .ToList();
            float averageMovieCount = GetAverageMovieCount(users, seenMovies);
            int lastMonthClicksCount = _dalContext.UserMovieSearches
                .GetAll()
                .Where(u => u.CreatedAt.Year == year &&
                            u.CreatedAt.Month == month)
                .ToList().Count;
            List<UserMovieSearch> userMovieSearches = _dalContext.UserMovieSearches.GetAll();
            List<Library.MachineLearningModels.PredictedMovieCount> predictedMoviesCount = new();
            foreach (UserRead user in users)
            {
                ApplicationUser applicationUser = _dalContext.Users.GetByUid(user.Uid);
                IList<string> roles = await _userManager.GetRolesAsync(applicationUser);
                if (roles.FirstOrDefault(r => r == "Administrator") != null)
                {
                    continue;
                }
                Library.MachineLearningModels.PredictedMovieCount predictedMovieCount = new()
                {
                    UserId = user.Uid.ToString(),
                    AverageMovieCount = averageMovieCount,
                    MyAverageMovieCount = seenMovies.Where(s => s.UserGUID == user.Uid.ToString()).ToList().Count,
                    AverageMovieClicks = GetAverageMovieClicks(users, userMovieSearches),
                    MyMovieClicks = userMovieSearches.Where(u => u.UserGUID == user.Uid.ToString()).ToList().Count,
                    AverageWatchLaterMovies = GetAverageMovieSubscriptions(users, movieSubscriptions),
                    MyAverageWatchLaterMovies = movieSubscriptions.Where(m => m.UserGUID == user.Uid.ToString()).ToList().Count
                };
                predictedMoviesCount.Add(predictedMovieCount);
            }
            return predictedMoviesCount;
        }

        public List<Library.Models._UI.MachineLearning.PredictedMovieCount> GetEachMonthByUser(string userUid)
        {
            List<PredictedMovieCount> predictingMovieCounts = _dalContext.PredictedMoviesCount.GetAll()
                                        .Where(u => u.UserGUID == userUid)
                                        .ToList();
            List<Library.Models._UI.MachineLearning.PredictedMovieCount> predictingMovieCountsMLModels = new();
            foreach (PredictedMovieCount predictingMovieCount in predictingMovieCounts)
            {
                int year = predictingMovieCount.CreatedAt.Year;
                int month = predictingMovieCount.CreatedAt.Month;

                if (predictingMovieCountsMLModels.Any(p => p.Year == year && p.Month == month))
                {
                    continue;
                }
                Library.Models._UI.MachineLearning.PredictedMovieCount predictingMovieCountMLModel = new()
                {
                    Year = year,
                    Month = month,
                    MovieCount = predictingMovieCount.MovieCount
                };
                predictingMovieCountsMLModels.Add(predictingMovieCountMLModel);
            }
            return predictingMovieCountsMLModels;
        }

        public List<Library.Models._UI.MachineLearning.PredictedMovieCount> GetEachMonth()
        {
            List<PredictedMovieCount> predictingMovieCounts = _dalContext.PredictedMoviesCount.GetAll().ToList();
            List<Library.Models._UI.MachineLearning.PredictedMovieCount> predictingMovieCountsMLModels = new();
            IDictionary<Tuple<int, int>, List<float>> dictionary = new Dictionary<Tuple<int, int>, List<float>>();
            foreach (PredictedMovieCount predictingMovieCount in predictingMovieCounts)
            {
                int year = predictingMovieCount.CreatedAt.Year;
                int month = predictingMovieCount.CreatedAt.Month;
                Tuple<int, int> dateTuple = Tuple.Create(year, month);
                if (dictionary.ContainsKey(dateTuple))
                {
                    dictionary[dateTuple].Add(predictingMovieCount.MovieCount);
                    continue;
                }
                dictionary.Add(dateTuple, new List<float>() { predictingMovieCount.MovieCount });
            }
            foreach (KeyValuePair<Tuple<int, int>, List<float>> keyValuePair in dictionary)
            {
                List<float> movieCounts = keyValuePair.Value;
                float averageMovieCount = movieCounts.Sum();
                predictingMovieCountsMLModels.Add(new()
                {
                    Year = keyValuePair.Key.Item1,
                    Month = keyValuePair.Key.Item2,
                    MovieCount = float.Parse(String.Format("{0:0.00}", averageMovieCount))
                });
            }
            return predictingMovieCountsMLModels;
        }

        public async Task ProcessPredictedMovieCountJobAction(int year, int month)
        {
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAll();
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;
            List<Library.MachineLearningModels.PredictedMovieCount> predictedMoviesCount = await GetDataByMonth(year, month);
            ICSVHandlerService csvHandler = new CSVHandlerServiceService("Files\\Predicting\\test_movies_count_predicted.csv");
            csvHandler.WriteCSV(predictedMoviesCount);
            List<string> predictedData = ScriptEngine.GetPredictedData("movieCount", "predict");
            csvHandler.RemoveLastColumn();
            csvHandler.UpdateCsvFile(predictedData, "FuturePredictedMovieCount");
            List<List<string>> predictedMoviesCountCsv = csvHandler.ReadCsvFile();
            predictedMoviesCountCsv = predictedMoviesCountCsv.Skip(1).ToList();
            csvHandler.AppendRowsToCsv("movieCount.csv", predictedMoviesCountCsv);
            List<string> userUids = predictedMoviesCountCsv.Select(s => s[0]).ToList();
            for (int i = 0; i < userUids.Count; i++)
            {
                string userUid = userUids[i];
                float predictedMovieCount = float.Parse(predictedData[i]);
                PredictedMovieCount predictedMovieCountModel = new()
                {
                    PredictedMovieCountGUID = Guid.NewGuid(),
                    CreatedAt = new DateTime(year, month, 1),
                    UserGUID = userUid,
                    MovieCount = predictedMovieCount
                };
                _dalContext.PredictedMoviesCount.Add(predictedMovieCountModel);
            }
            ScriptEngine.TrainToPredictModel("movieCount", "training", currentAlgorithmName);
        }
    }
}