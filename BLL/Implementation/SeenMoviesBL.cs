using BLL.Converters.Movie;
using BLL.Converters.SeenMovie;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models;
using Library.Models.Movie;
using Library.Models.SeenMovie;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BLL.Implementation
{
    public class SeenMoviesBL : BusinessObject, ISeenMovies
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SeenMoviesBL(DAL.Interfaces.IDALContext dalContext,
            IHttpContextAccessor httpContextAccessor) : base(dalContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public SeenMovieCreate Add(SeenMovieCreate seenMovie)
        {
            SeenMovie addedSeenMovie = SeenMovieCreateConverter.ToDALModel(seenMovie);
            if (addedSeenMovie == null)
            {
                return null;
            }
            return SeenMovieCreateConverter.ToBLLModel(_dalContext.SeenMovies.Add(addedSeenMovie));
        }

        public SeenMovieRead Delete(Guid uid)
        {
            SeenMovie deletedSeenMovie = _dalContext.SeenMovies.Delete(uid);
            if (deletedSeenMovie == null)
            {
                return null;
            }
            return SeenMovieReadConverter.ToBLLModel(deletedSeenMovie);
        }

        public List<SeenMovieRead> GetAll()
        {
            return _dalContext.SeenMovies
               .GetAll()
               .Select(seenMovie => SeenMovieReadConverter.ToBLLModel(seenMovie))
               .ToList();
        }

        public List<MovieRead> GetAllByUser(string userUid)
        {
            List<SeenMovie> seenMovies = _dalContext
                .SeenMovies
                .GetAllByUser(userUid);

            return seenMovies
                .Select(movieSubscription => MovieReadConverter.ToBLLModel(movieSubscription.Movie))
                .ToList();
        }

        public SeenMovieRead? GetByUid(Guid uid)
        {
            SeenMovie? seenMovie = _dalContext.SeenMovies.GetByUid(uid);
            if (seenMovie == null)
            {
                return null;
            }
            return SeenMovieReadConverter
                    .ToBLLModel(seenMovie);
        }

        public SeenMovieRead GetByUserAndMovie(Guid movieUid)
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            SeenMovie? seenMovie = _dalContext.SeenMovies.GetByUserAndMovie(movieUid, userEntity.Id);
            if (seenMovie == null)
            {
                return null;
            }
            SeenMovieRead movieSubscriptionRead = SeenMovieReadConverter.ToBLLModel(seenMovie);
            return movieSubscriptionRead;
        }

        public List<MonthlyAppUsageModel> GetMonthlySeenMoviesByUser()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            List<SeenMovie> seenMovies = _dalContext.SeenMovies
                .GetAll()
                .Where(s => s.UserGUID == userEntity.Id)
                .ToList();
            List<MonthlyAppUsageModel> monthlyAppUsage = new List<MonthlyAppUsageModel>();
            foreach (SeenMovie seenMovie in seenMovies)
            {
                MonthlyAppUsageModel? existingUsage = monthlyAppUsage.FirstOrDefault(m => m.Year == seenMovie.CreatedAt.Year && m.Month == seenMovie.CreatedAt.Month);
                if (existingUsage == null)
                {
                    MonthlyAppUsageModel monthlyAppUsageModel = new()
                    {
                        Month = seenMovie.CreatedAt.Month,
                        Year = seenMovie.CreatedAt.Year,
                        SeenMovies = new List<SeenMovieRead>() { SeenMovieReadConverter.ToBLLModel(seenMovie) }
                    };
                    monthlyAppUsage.Add(monthlyAppUsageModel);
                    continue;
                }
                existingUsage.SeenMovies!.Add(SeenMovieReadConverter.ToBLLModel(seenMovie));
            }
            return monthlyAppUsage;
        }

        public List<TopGenreModel> GetTopSeenGenresByUser()
        {
            var email = _httpContextAccessor.HttpContext!.User?.FindFirstValue(ClaimTypes.Name);
            ApplicationUser? userEntity = _dalContext.Users.GetByEmail(email!);
            if (userEntity == null)
            {
                return null;
            }
            List<SeenMovie> loggedInUserSeenMovies = new(_dalContext.SeenMovies
                                                          .GetAll()
                                                          .Where(s => s.UserGUID == userEntity.Id)
                                                          .ToList());

            List<string> genres = _dalContext.Movies.GetMovieGenres();
            List<TopGenreModel> topMovieGenres = new List<TopGenreModel>();

            foreach (SeenMovie seenMovie in loggedInUserSeenMovies)
            {
                string[] currentMovieGenres = seenMovie.Movie.Genres.Split(',');

                foreach (string genre in currentMovieGenres)
                {
                    TopGenreModel? existingTopGenreModel = topMovieGenres.FirstOrDefault(t => t.Genre == genre);
                    if (existingTopGenreModel == null)
                    {
                        TopGenreModel topGenreModel = new()
                        {
                            Genre = genre,
                            SeenMovies = new List<SeenMovieRead>() { SeenMovieReadConverter.ToBLLModel(seenMovie) }
                        };
                        topMovieGenres.Add(topGenreModel);
                        continue;
                    }
                    existingTopGenreModel.SeenMovies.Add(SeenMovieReadConverter.ToBLLModel(seenMovie));
                }
            }
            topMovieGenres = (from topMovieGenre in topMovieGenres
                              orderby topMovieGenre.SeenMovies.Count
                              descending
                              select topMovieGenre).ToList();

            return topMovieGenres;
        }

        public List<MonthlyAppUsageModel> GetMonthlySeenMovies()
        {
            List<SeenMovie> seenMovies = _dalContext.SeenMovies
                .GetAll()
                .ToList();
            List<MonthlyAppUsageModel> monthlyAppUsage = new List<MonthlyAppUsageModel>();
            foreach (SeenMovie seenMovie in seenMovies)
            {
                MonthlyAppUsageModel? existingUsage = monthlyAppUsage.FirstOrDefault(m => m.Year == seenMovie.CreatedAt.Year && m.Month == seenMovie.CreatedAt.Month);
                if (existingUsage == null)
                {
                    MonthlyAppUsageModel monthlyAppUsageModel = new()
                    {
                        Month = seenMovie.CreatedAt.Month,
                        Year = seenMovie.CreatedAt.Year,
                        SeenMovies = new List<SeenMovieRead>() { SeenMovieReadConverter.ToBLLModel(seenMovie) }
                    };
                    monthlyAppUsage.Add(monthlyAppUsageModel);
                    continue;
                }
                existingUsage.SeenMovies!.Add(SeenMovieReadConverter.ToBLLModel(seenMovie));
            }
            return monthlyAppUsage;
        }

        public List<TopGenreModel> GetTopSeenGenres()
        {
            List<SeenMovie> loggedInUserSeenMovies = new(_dalContext.SeenMovies
                                                          .GetAll()
                                                          .ToList());

            List<string> genres = _dalContext.Movies.GetMovieGenres();
            List<TopGenreModel> topMovieGenres = new List<TopGenreModel>();

            foreach (SeenMovie seenMovie in loggedInUserSeenMovies)
            {
                string[] currentMovieGenres = seenMovie.Movie.Genres.Split(',');

                foreach (string genre in currentMovieGenres)
                {
                    TopGenreModel? existingTopGenreModel = topMovieGenres.FirstOrDefault(t => t.Genre == genre);
                    if (existingTopGenreModel == null)
                    {
                        TopGenreModel topGenreModel = new()
                        {
                            Genre = genre,
                            SeenMovies = new List<SeenMovieRead>() { SeenMovieReadConverter.ToBLLModel(seenMovie) }
                        };
                        topMovieGenres.Add(topGenreModel);
                        continue;
                    }
                    existingTopGenreModel.SeenMovies.Add(SeenMovieReadConverter.ToBLLModel(seenMovie));
                }
            }
            topMovieGenres = (from topMovieGenre in topMovieGenres
                              orderby topMovieGenre.SeenMovies.Count
                              descending
                              select topMovieGenre).ToList();

            return topMovieGenres;
        }
    }
}