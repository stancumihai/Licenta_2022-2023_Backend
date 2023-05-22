using BLL.Converters.PredictedMovieCount;
using BLL.Converters.User;
using BLL.Core;
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

        public List<PredictedMovieCountRead> GetAllByDate(int year, int month)
        {
            return _dalContext.PredictedMoviesCount
                .GetAllByDate(year, month)
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

        public async Task<List<Library.MachineLearningModels.PredictedMovieCount>> GetLastMonthData()
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
            float averageMovieCount = GetAverageMovieCount(users, seenMovies);
            int lastMonthClicksCount = _dalContext.UserMovieSearches
                .GetAll()
                .Where(u => u.CreatedAt.Year == currentYear &&
                            u.CreatedAt.Month == currentMonth)
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
    }
}