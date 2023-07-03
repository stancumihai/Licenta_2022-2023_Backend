using BLL.Converters.PredictedMovieRuntime;
using BLL.Converters.User;
using BLL.Core;
using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces.MachineLearning;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.MachineLearning;
using Library.Models.PredictedMovieRuntime;
using Library.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BLL.Implementation.MachineLearning
{
    public class PredictedMoviesRuntimeBL : BusinessObject, IPredictedMoviesRuntime
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PredictedMoviesRuntimeBL(IDALContext dalContext, UserManager<ApplicationUser> userManager) : base(dalContext)
        {
            _userManager = userManager;
        }

        public PredictedMovieRuntimeCreate Add(PredictedMovieRuntimeCreate predictedMovieRuntime)
        {
            PredictedMovieRuntime addedPredictedMovieRuntime = _dalContext.PredictedMoviesRuntime.Add(PredictedMovieRuntimeCreateConverter.ToDALModel(predictedMovieRuntime));
            if (addedPredictedMovieRuntime == null)
            {
                return null;
            }
            return PredictedMovieRuntimeCreateConverter.ToBLLModel(addedPredictedMovieRuntime);
        }

        public List<PredictedMovieRuntimeRead> GetAll()
        {
            return _dalContext.PredictedMoviesRuntime
                .GetAll()
                .Select(p => PredictedMovieRuntimeReadConverter.ToBLLModel(p))
                .ToList();
        }

        public List<PredictedMovieRuntimeRead> GetAllByDate(int year, int month)
        {
            return _dalContext.PredictedMoviesRuntime
                 .GetAllByDate(year, month)
                 .Select(p => PredictedMovieRuntimeReadConverter.ToBLLModel(p))
                 .ToList();
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

        private static float GetAverageMovieSubscriptionsRuntime(List<UserRead> users, List<MovieSubscription> movieSubscriptions)
        {
            float totalRuntimes = 0.0f;
            int usersWithSeenMovies = 0;
            foreach (UserRead user in users)
            {
                float userRuntime = movieSubscriptions
                   .Where(s => s.UserGUID == user.Uid.ToString())
                   .Select(s => s.Movie)
                   .Sum(m => m.Runtime);
                if (userRuntime > 0)
                {
                    totalRuntimes += userRuntime;
                    usersWithSeenMovies++;
                }
            }
            return (float)totalRuntimes / usersWithSeenMovies;
        }

        private static float GetAverageMovieRuntime(List<UserRead> users, List<SeenMovie> seenMovies)
        {
            float movieCount = 0.0f;
            int usersWithSeenMovies = 0;
            foreach (UserRead user in users)
            {
                float userRuntime = seenMovies
                   .Where(s => s.UserGUID == user.Uid.ToString())
                   .Select(s => s.Movie)
                   .Sum(m => m.Runtime);
                if (userRuntime > 0)
                {
                    movieCount += userRuntime;
                    usersWithSeenMovies++;
                }
            }
            return (float)movieCount / usersWithSeenMovies;
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

        private async Task<List<Library.MachineLearningModels.PredictedMovieRuntime>> GetDataByMonth(int year, int month)
        {
            List<UserRead> users = _dalContext.Users.GetAll()!
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
            float averageMovieRuntime = GetAverageMovieRuntime(users, seenMovies);
            int lastMonthClicksCount = _dalContext.UserMovieSearches
                .GetAll()
                .Where(u => u.CreatedAt.Year == year &&
                            u.CreatedAt.Month == month)
                .ToList().Count;
            List<UserMovieSearch> userMovieSearches = _dalContext.UserMovieSearches.GetAll();
            List<Library.MachineLearningModels.PredictedMovieRuntime> predictedMoviesRuntime = new();
            decimal averageUsersRating = Math.Round(GetAverageUsersRating(year, month), 2);
            int i = 0;
            Random random = new();
            foreach (UserRead user in users)
            {
                ApplicationUser applicationUser = _dalContext.Users.GetByUid(user.Uid)!;
                IList<string> roles = await _userManager.GetRolesAsync(applicationUser);
                if (roles.FirstOrDefault(r => r == "Administrator") != null)
                {
                    continue;
                }
                decimal averageUserRating = Math.Round(GetAverageUserRating(user.Uid.ToString(), year, month), 2);
                Library.MachineLearningModels.PredictedMovieRuntime predictedMovieRuntime = new()
                {
                    UserId = user.Uid.ToString(),
                    AverageRuntime = averageMovieRuntime,
                    MyAverageRuntime = seenMovies.Where(s => s.UserGUID == user.Uid.ToString())
                                                 .Select(s => s.Movie)
                                                 .Sum(m => m.Runtime),
                    AverageMovieClicks = GetAverageMovieClicks(users, userMovieSearches),
                    MyMovieClicks = userMovieSearches.Where(u => u.UserGUID == user.Uid.ToString()).ToList().Count,
                    AverageWatchLaterMoviesRuntime = GetAverageMovieSubscriptionsRuntime(users, movieSubscriptions),
                    MyAverageRating = averageUsersRating,
                    AverageRating = averageUserRating,
                    MyAverageWatchLaterMoviesRuntime = movieSubscriptions
                                                        .Where(s => s.UserGUID == user.Uid.ToString())
                                                        .Select(s => s.Movie)
                                                        .Sum(m => m.Runtime)
                };
                if (i % 5 == 0)
                {
                    predictedMovieRuntime.AverageRuntime += random.Next(1, (int)predictedMovieRuntime.AverageRuntime / 7);
                    predictedMovieRuntime.MyAverageRuntime += random.Next(1, (int)predictedMovieRuntime.MyAverageRuntime / 7);
                    predictedMovieRuntime.AverageMovieClicks += random.Next(1, (int)predictedMovieRuntime.AverageMovieClicks / 7 );
                    predictedMovieRuntime.MyMovieClicks += random.Next(1, predictedMovieRuntime.MyMovieClicks / 7);
                    predictedMovieRuntime.MyAverageWatchLaterMoviesRuntime += random.Next(1, predictedMovieRuntime.MyAverageWatchLaterMoviesRuntime / 7);
                }
                if (i % 10 == 0)
                {
                    predictedMovieRuntime.AverageRuntime = Math.Abs(predictedMovieRuntime.AverageRuntime - random.Next(1, (int)predictedMovieRuntime.AverageRuntime / 7));
                    predictedMovieRuntime.MyAverageRuntime = Math.Abs(predictedMovieRuntime.MyAverageRuntime - random.Next(1, (int)predictedMovieRuntime.MyAverageRuntime / 7));
                    predictedMovieRuntime.AverageMovieClicks = Math.Abs(predictedMovieRuntime.AverageMovieClicks - random.Next(1, (int)predictedMovieRuntime.AverageMovieClicks / 7));
                    predictedMovieRuntime.MyMovieClicks = Math.Abs(predictedMovieRuntime.MyMovieClicks - random.Next(1, predictedMovieRuntime.MyMovieClicks / 7));
                    predictedMovieRuntime.MyAverageWatchLaterMoviesRuntime = Math.Abs(predictedMovieRuntime.MyAverageWatchLaterMoviesRuntime - random.Next(1, predictedMovieRuntime.MyAverageWatchLaterMoviesRuntime / 7));
                }
                i++;
                predictedMoviesRuntime.Add(predictedMovieRuntime);
            }
            return predictedMoviesRuntime;
        }

        public List<Library.Models._UI.MachineLearning.PredictedMovieRuntime> GetEachMonthByUser(string userUid)
        {
            List<PredictedMovieRuntime> predictingMovieRuntimes = _dalContext.PredictedMoviesRuntime.GetAll()
                                       .Where(u => u.UserGUID == userUid)
                                       .ToList();
            List<Library.Models._UI.MachineLearning.PredictedMovieRuntime> predictingMovieRuntimeMLModels = new();
            foreach (PredictedMovieRuntime predictingMovieRuntime in predictingMovieRuntimes)
            {
                int year = predictingMovieRuntime.CreatedAt.Year;
                int month = predictingMovieRuntime.CreatedAt.Month;

                if (predictingMovieRuntimeMLModels.Any(p => p.Year == year && p.Month == month))
                {
                    continue;
                }
                Library.Models._UI.MachineLearning.PredictedMovieRuntime predictingMovieRuntimeMLModel = new()
                {
                    Year = year,
                    Month = month,
                    Runtime = predictingMovieRuntime.MovieRuntime
                };
                predictingMovieRuntimeMLModels.Add(predictingMovieRuntimeMLModel);
            }
            return predictingMovieRuntimeMLModels;
        }


        public async Task ProcessPredictedMovieRuntimeJobAction(int year, int month)
        {
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAll();
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;
            List<Library.MachineLearningModels.PredictedMovieRuntime> predictedMoviesRuntime = await GetDataByMonth(year, month);
            ICSVHandlerService csvHandler = new CSVHandlerService("Files\\Predicting\\test_movies_runtimes_predicted.csv");
            csvHandler.WriteCSV(predictedMoviesRuntime);
            List<string> predictedData = ScriptEngine.GetPredictedData("movieRuntime", "predict");
            csvHandler.RemoveLastColumn();
            csvHandler.UpdateCsvFile(predictedData, "FuturePredictedMovieRuntime");
            List<List<string>> predictedMoviesRuntimeCSV = csvHandler.ReadCsvFile();
            predictedMoviesRuntimeCSV = predictedMoviesRuntimeCSV.Skip(1).ToList();
            List<string> userUids = predictedMoviesRuntimeCSV.Select(s => s[0]).ToList();
            for (int i = 0; i < userUids.Count; i++)
            {
                string userUid = userUids[i];
                float predictedMovieRuntime = float.Parse(predictedData[i]);
                PredictedMovieRuntime predictedMovieRuntimeModel = new()
                {
                    PredictedMovieRuntimeGUID = Guid.NewGuid(),
                    CreatedAt = new DateTime(year, month, 1),
                    UserGUID = userUid,
                    MovieRuntime = predictedMovieRuntime
                };
                _dalContext.PredictedMoviesRuntime.Add(predictedMovieRuntimeModel);
            }
            csvHandler.AppendRowsToCsv("Files\\Training\\movieRuntime.csv", predictedMoviesRuntimeCSV);
            ScriptEngine.TrainToPredictModel("movieRuntime", "training", currentAlgorithmName);
        }

        public List<Library.Models._UI.MachineLearning.PredictedMovieRuntime> GetEachMonth()
        {
            List<PredictedMovieRuntime> predictingMoviesRuntime = _dalContext.PredictedMoviesRuntime.GetAll().ToList();
            List<Library.Models._UI.MachineLearning.PredictedMovieRuntime> predictingMoviesRuntimeMLModels = new();
            IDictionary<Tuple<int, int>, List<float>> dictionary = new Dictionary<Tuple<int, int>, List<float>>();
            foreach (PredictedMovieRuntime predictingMovieRuntime in predictingMoviesRuntime)
            {
                if (predictingMovieRuntime.MovieRuntime == 0)
                {
                    continue;
                }
                int year = predictingMovieRuntime.CreatedAt.Year;
                int month = predictingMovieRuntime.CreatedAt.Month;
                Tuple<int, int> dateTuple = Tuple.Create(year, month);
                if (dictionary.ContainsKey(dateTuple))
                {
                    dictionary[dateTuple].Add(predictingMovieRuntime.MovieRuntime);
                    continue;
                }
                dictionary.Add(dateTuple, new List<float>() { predictingMovieRuntime.MovieRuntime });
            }
            foreach (KeyValuePair<Tuple<int, int>, List<float>> keyValuePair in dictionary)
            {
                List<float> movieRuntimes = keyValuePair.Value;
                float averageMovieRuntime = movieRuntimes.Sum();
                predictingMoviesRuntimeMLModels.Add(new()
                {
                    Year = keyValuePair.Key.Item1,
                    Month = keyValuePair.Key.Item2,
                    Runtime = float.Parse(String.Format("{0:0.00}", averageMovieRuntime))
                });
            }
            return predictingMoviesRuntimeMLModels;
        }
    }
}