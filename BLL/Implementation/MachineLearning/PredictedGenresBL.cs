using BLL.Converters.PredictedGenre;
using BLL.Converters.User;
using BLL.Core;
using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces.MachineLearning;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.MachineLearning;
using Library.Models.PredictedGenre;
using Library.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BLL.Implementation.MachineLearning
{
    public class PredictedGenresBL : BusinessObject, IPredictedGenres
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PredictedGenresBL(IDALContext dalContext,
            UserManager<ApplicationUser> userManager) : base(dalContext)
        {
            _userManager = userManager;
        }

        public PredictedGenreCreate Add(PredictedGenreCreate predictedGenre)
        {
            PredictedGenre addedPredictedGenre = _dalContext.PredictedGenres.Add(PredictedGenreCreateConverter.ToDALModel(predictedGenre));
            if (addedPredictedGenre == null)
            {
                return null;
            }
            return PredictedGenreCreateConverter.ToBLLModel(addedPredictedGenre);
        }

        public List<PredictedGenreRead> GetAll()
        {
            return _dalContext.PredictedGenres
                   .GetAll()
                   .Select(p => PredictedGenreReadConverter.ToBLLModel(p))
                   .ToList();

        }

        private Tuple<string, string> GetAverageGenres(List<Movie> movies)
        {
            IDictionary<string, int> genresDictionary = new Dictionary<string, int>();
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            for (int i = 0; i < genres.Count; i++)
            {
                genresDictionary.Add(genres[i], 0);
            }
            foreach (Movie movie in movies)
            {
                string[] movieGenres = movie.Genres.Split(',');
                foreach (string genre in movieGenres)
                {
                    if (genre == "Sci-Fi")
                    {
                        string scifiGenre = "SciFi";
                        genresDictionary[scifiGenre]++;
                        continue;
                    }
                    if (genre == "Film-Noir")
                    {
                        string filNoirGenre = "FilmNoir";
                        genresDictionary[filNoirGenre]++;
                        continue;
                    }
                    if (genre == "Reality-TV")
                    {
                        string realityTvGenre = "RealityTv";
                        genresDictionary[realityTvGenre]++;
                        continue;
                    }
                    genresDictionary[genre]++;
                }
            }

            IEnumerable<string> mostappreciatedPersonsSortedGenres = from genresDicEntry in genresDictionary
                                                                     orderby genresDicEntry.Value
                                                                     descending
                                                                     select genresDicEntry.Key;
            return Tuple.Create(mostappreciatedPersonsSortedGenres.ToList()[0],
                                mostappreciatedPersonsSortedGenres.ToList()[1]);
        }

        private static List<Movie> GetLastMonthMovies(List<SeenMovie> seenMovies,
            List<MovieSubscription> movieSubscriptions,
            List<LikedMovie> likedMovies)
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            seenMovies = seenMovies
               .Where(s => s.CreatedAt.Year == currentYear &&
                           s.CreatedAt.Month == currentMonth)
               .ToList();
            movieSubscriptions = movieSubscriptions
                .Where(s => s.CreatedAt.Year == currentYear &&
                            s.CreatedAt.Month == currentMonth)
                .ToList();
            likedMovies = likedMovies
                .Where(s => s.CreatedAt.Year == currentYear &&
                            s.CreatedAt.Month == currentMonth)
                .ToList();
            List<Movie> movies = seenMovies.Select(s => s.Movie)
                            .Concat(
                                movieSubscriptions.Select(m => m.Movie)
                                    .Concat(likedMovies.Select(l => l.Movie)
                                    ))
                            .ToList();
            return movies;
        }

        private static List<Movie> GetLastMonthMoviesByUser(string userId,
            List<SeenMovie> seenMovies,
            List<MovieSubscription> movieSubscriptions,
            List<LikedMovie> likedMovies)
        {

            seenMovies = seenMovies
              .Where(s => s.UserGUID == userId)
              .ToList();
            movieSubscriptions = movieSubscriptions
               .Where(s => s.UserGUID == userId)
               .ToList();
            likedMovies = likedMovies
                .Where(s => s.UserGUID == userId)
                .ToList();
            List<Movie> movies = seenMovies.Select(s => s.Movie)
                            .Concat(
                                 movieSubscriptions.Select(m => m.Movie)
                            .Concat(
                                 likedMovies.Select(l => l.Movie)))
                            .ToList();
            return movies;
        }

        private Tuple<string, string> GetAverageDirectors(List<Movie> movies)
        {
            List<Person> directors = _dalContext
                .Persons
                .GetAll()
                .Where(p => p.Professions.Split(',')
                .Contains("director"))
                .ToList();
            List<KnownFor> knownFors = new();
            foreach (Movie movie in movies)
            {
                knownFors.AddRange(movie.KnowFor);
            }
            IDictionary<string, int> directorsDictionary = new Dictionary<string, int>();
            foreach (KnownFor knownFor in knownFors)
            {
                Person? existingDirector = directors.FirstOrDefault(f => f.PersonGUID == knownFor.PersonGUID);
                if (existingDirector != null)
                {
                    if (directorsDictionary.ContainsKey(existingDirector.Name))
                    {
                        directorsDictionary[existingDirector.Name]++;
                        continue;
                    }
                    directorsDictionary.Add(existingDirector.Name, 1);

                }
            }
            IEnumerable<string> mostWatchedirectors = from directorsDictionaryEntry in directorsDictionary
                                                      orderby directorsDictionaryEntry.Value
                                                      descending
                                                      select directorsDictionaryEntry.Key;
            if (mostWatchedirectors.ToList().Count == 0)
            {
                return Tuple.Create("", "");
            }
            if (mostWatchedirectors.ToList().Count == 1)
            {
                return Tuple.Create(mostWatchedirectors.ToList()[0], "");
            }
            return Tuple.Create(mostWatchedirectors.ToList()[0],
                                mostWatchedirectors.ToList()[1]);
        }

        private async Task<List<Library.MachineLearningModels.PredictedGenre>> GetDataByMonth(int year, int month)
        {
            List<SeenMovie> seenMovies = _dalContext.SeenMovies.GetAll();
            List<MovieSubscription> movieSubscriptions = _dalContext.MovieSubscriptions.GetAll();
            List<LikedMovie> likedMovies = _dalContext.LikedMovies.GetAll();
            List<Movie> movies = GetLastMonthMovies(seenMovies, movieSubscriptions, likedMovies);
            Tuple<string, string> topGlobalGenres = GetAverageGenres(movies);
            Tuple<string, string> topGlobalDirectors = GetAverageDirectors(movies);
            List<UserRead> users = _dalContext.Users.GetAll()
                .Select(u => UserReadConverter.ToBLLModel(u))
                .ToList();
            int lastMonthClicksCount = _dalContext.UserMovieSearches
                .GetAll()
                .Where(u => u.CreatedAt.Year == year && u.CreatedAt.Month == month)
                .ToList().Count;
            List<Library.MachineLearningModels.PredictedGenre> predictedGenres = new();

            foreach (UserRead user in users)
            {
                ApplicationUser applicationUser = _dalContext.Users.GetByUid(user.Uid);
                IList<string> roles = await _userManager.GetRolesAsync(applicationUser);
                if (roles.FirstOrDefault(r => r == "Administrator") != null)
                {
                    continue;
                }
                List<Movie> userMovies = GetLastMonthMoviesByUser(user.Uid.ToString(),
                    seenMovies, movieSubscriptions, likedMovies);
                if (userMovies.Count == 0)
                {
                    continue;
                }
                Tuple<string, string> topPersonalGenres = GetAverageGenres(userMovies);
                Tuple<string, string> topPersonalDirectors = GetAverageDirectors(userMovies);
                if (topPersonalDirectors.Item1 == "")
                {
                    continue;
                }
                Library.MachineLearningModels.PredictedGenre predictedGenre = new()
                {
                    UserId = user.Uid.ToString(),
                    AverageGenre1 = topGlobalGenres.Item1,
                    AverageGenre2 = topGlobalGenres.Item2,
                    MyAverageGenre1 = topPersonalGenres.Item1,
                    MyAverageGenre2 = topPersonalGenres.Item2,
                    AverageDirector = topGlobalDirectors.Item1,
                    MyAverageDirector = topPersonalDirectors.Item1,
                    Clicks = lastMonthClicksCount
                };
                predictedGenres.Add(predictedGenre);
            }
            return predictedGenres;
        }

        private List<Library.Models._UI.MachineLearning.PredictedGenre> GetPredictedGenresUIData(List<PredictedGenre> predictingGenres)
        {
            List<Library.Models._UI.MachineLearning.PredictedGenre> predictingGenresMLModels = new();
            IDictionary<Tuple<int, int>, List<string>> dictionary = new Dictionary<Tuple<int, int>, List<string>>();
            foreach (PredictedGenre predictedGenre in predictingGenres)
            {
                int year = predictedGenre.CreatedAt.Year;
                int month = predictedGenre.CreatedAt.Month;
                Tuple<int, int> dateTuple = Tuple.Create(year, month);
                if (dictionary.ContainsKey(dateTuple))
                {
                    dictionary[dateTuple].Add(predictedGenre.Genre);
                    continue;
                }
                dictionary.Add(dateTuple, new List<string>() { predictedGenre.Genre });
            }
            foreach (KeyValuePair<Tuple<int, int>, List<string>> keyValuePair in dictionary)
            {
                List<string> genres = keyValuePair.Value;
                genres.Sort();
                IDictionary<string, int> genresSortedDictionary = new Dictionary<string, int>();
                foreach (string genre in genres)
                {
                    if (genresSortedDictionary.ContainsKey(genre))
                    {
                        genresSortedDictionary[genre]++;
                        continue;
                    }
                    genresSortedDictionary.Add(genre, 1);
                }
                List<Library.Models._UI.MachineLearning.GenreMonthlyCount> genreMonthlyCounts = new();
                foreach (KeyValuePair<string, int> genresSortedDictionaryKeyValuePair in genresSortedDictionary)
                {
                    genreMonthlyCounts.Add(new()
                    {
                        Genre = genresSortedDictionaryKeyValuePair.Key,
                        Count = genresSortedDictionaryKeyValuePair.Value
                    });
                }
                genreMonthlyCounts = (from genreMonthlyCount in genreMonthlyCounts orderby genreMonthlyCount.Count descending select genreMonthlyCount).ToList();
                var mostPredictedGenresCurrentMonth = from genresDicEntry in genresSortedDictionary
                                                      orderby genresDicEntry.Value
                                                      descending
                                                      select genresDicEntry.Key;
                predictingGenresMLModels.Add(new()
                {
                    Year = keyValuePair.Key.Item1,
                    Month = keyValuePair.Key.Item2,
                    GenreMonthlyCounts = genreMonthlyCounts
                });
            }
            return predictingGenresMLModels;
        }

        public List<Library.Models._UI.MachineLearning.PredictedGenre> GetEachMonthByUser(string userUid)
        {
            List<PredictedGenre> predictingGenres = _dalContext.PredictedGenres.GetAll()
                                        .Where(u => u.UserGUID == userUid)
                                        .ToList();
            List<Library.Models._UI.MachineLearning.PredictedGenre> predictingGenresMLModels = GetPredictedGenresUIData(predictingGenres);
            return predictingGenresMLModels;
        }

        public List<Library.Models._UI.MachineLearning.PredictedGenre> GetEachMonth()
        {
            List<PredictedGenre> predictingGenres = _dalContext.PredictedGenres
                .GetAll()
                .ToList();
            List<Library.Models._UI.MachineLearning.PredictedGenre> predictingGenresMLModels = GetPredictedGenresUIData(predictingGenres);
            return predictingGenresMLModels;
        }

        public async Task ProcessPredictedGenreJobAction(int year, int month)
        {
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAll();
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;
            List<Library.MachineLearningModels.PredictedGenre> predictedGenres = await GetDataByMonth(year, month);
            ICSVHandlerService csvHandler = new CSVHandlerService("Files\\Predicting\\test_genres_predicted.csv");
            csvHandler.WriteCSV(predictedGenres);
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            List<string> predictedData = ScriptEngine.GetPredictedData("genres", "predict");
            csvHandler.RemoveLastColumn();
            csvHandler.UpdateCsvFile(predictedData, "FuturePredictedGenre");
            List<List<string>> predictedGenreData = csvHandler.ReadCsvFile();
            predictedGenreData = predictedGenreData.Skip(1).ToList();
            csvHandler.AppendRowsToCsv("genres.csv", predictedGenreData);
            List<string> userUids = predictedGenreData.Select(s => s[0]).ToList();
            for (int i = 0; i < userUids.Count; i++)
            {
                string userUid = userUids[i];
                string predictedGenre = predictedData[i];
                if (predictedGenre == "SciFi")
                {
                    predictedGenre = "Sci-Fi";
                }
                if (predictedGenre == "FilmNoir")
                {
                    predictedGenre = "Film-Noir";
                }
                if (!genres.Contains(predictedGenre))
                {
                    continue;
                }
                PredictedGenre predictedGenreModel = new()
                {
                    PredictedGenreGUID = Guid.NewGuid(),
                    CreatedAt = new DateTime(year, month, 1),
                    UserGUID = userUid,
                    Genre = predictedGenre
                };
                _dalContext.PredictedGenres.Add(predictedGenreModel);
            }
            ScriptEngine.TrainToPredictModel("genres", "training", currentAlgorithmName);
        }
    }
}