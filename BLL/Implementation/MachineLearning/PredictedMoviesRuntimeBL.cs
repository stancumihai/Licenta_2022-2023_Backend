using BLL.Converters.PredictedMovieRuntime;
using BLL.Converters.User;
using BLL.Core;
using BLL.Interfaces.MachineLearning;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.MachineLearning;
using Library.Enums;
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

        public async Task<List<Library.MachineLearningModels.PredictedMovieRuntime>> GetLastMonthData()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            //currentMonth--;
            //if (currentMonth == 0)
            //{
            //    currentYear--;
            //    currentMonth = 12;
            //}
            List<UserRead> users = _dalContext.Users.GetAll()
                .Select(u => UserReadConverter.ToBLLModel(u))
                .ToList();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies.GetAll()
                .Where(s => s.CreatedAt.Year == currentYear && s.CreatedAt.Month == currentMonth)
                .ToList();
            List<MovieSubscription> movieSubscriptions = _dalContext.MovieSubscriptions
                .GetAll()
                .Where(s => s.CreatedAt.Year == currentYear &&
                            s.CreatedAt.Month == currentMonth)
                .ToList();
            List<LikedMovie> likedMovies = _dalContext.LikedMovies.GetAll()
              .Where(s => s.CreatedAt.Year == currentYear &&
                          s.CreatedAt.Month == currentMonth)
              .ToList();
            float averageMovieRuntime = GetAverageMovieRuntime(users, seenMovies);
            int lastMonthClicksCount = _dalContext.UserMovieSearches
                .GetAll()
                .Where(u => u.CreatedAt.Year == currentYear &&
                            u.CreatedAt.Month == currentMonth)
                .ToList().Count;
            List<UserMovieSearch> userMovieSearches = _dalContext.UserMovieSearches.GetAll();
            List<Library.MachineLearningModels.PredictedMovieRuntime> predictedMoviesRuntime = new();
            foreach (UserRead user in users)
            {
                ApplicationUser applicationUser = _dalContext.Users.GetByUid(user.Uid);
                IList<string> roles = await _userManager.GetRolesAsync(applicationUser);
                if (roles.FirstOrDefault(r => r == "Administrator") != null)
                {
                    continue;
                }
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
                    MyAverageWatchLaterMoviesRuntime = movieSubscriptions
                                                        .Where(s => s.UserGUID == user.Uid.ToString())
                                                        .Select(s => s.Movie)
                                                        .Sum(m => m.Runtime)
                };
                predictedMoviesRuntime.Add(predictedMovieRuntime);
            }
            return predictedMoviesRuntime;
        }
    }
}