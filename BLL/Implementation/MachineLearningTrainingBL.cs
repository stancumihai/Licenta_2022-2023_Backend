using BLL.Core;
using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Library.MachineLearningModels;

namespace BLL.Implementation
{
    public class MachineLearningTrainingBL : BusinessObject, IMachineLearningTraining
    {
        public static readonly int MAX_TRAINING_RECORDS = 10000;

        public MachineLearningTrainingBL(IDALContext dalContext) : base(dalContext)
        {
        }

        private static Tuple<string, string> GetAverageGenres(List<Movie> movies, List<string> genres)
        {
            IDictionary<string, int> genresDictionary = new Dictionary<string, int>();
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


        public decimal GetAverageUsersRating()
        {
            List<UserMovieRating> userMovieRatings = _dalContext.UserMovieRatings.GetAll();
            decimal summedRating = userMovieRatings.Sum(f => f.Rating);
            if (summedRating == 0)
            {
                return 1;
            }
            return summedRating / userMovieRatings.Count;
        }

        public decimal GetAverageUserRating(string userUid)
        {
            List<UserMovieRating> userMovieRatings = _dalContext.UserMovieRatings.GetAll().Where(u => u.UserGUID == userUid).ToList();
            decimal summedRating = userMovieRatings.Sum(f => f.Rating);
            if (summedRating == 0)
            {
                return 1;
            }
            return summedRating / userMovieRatings.Count;
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
        public string GetMostWatchedGenre(List<Movie> movies)
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
            return (from topMovieGenre in topMovieGenres
                    orderby topMovieGenre.Value
                    descending
                    select topMovieGenre.Key).ToList()[0];
        }
        public string GetMostWatchedMovie(List<Movie> movies)
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
            return (from topSeenMovie in topSeenMovies
                    orderby topSeenMovie.Value
                    descending
                    select topSeenMovie.Key)
                    .ToList()[0];
        }
        public static List<Movie> GetRandomGeneratedMovies(List<Movie> movies, int monthNumber)
        {
            List<Movie> selectedMovies = new();
            int takeTries = monthNumber;
            bool takes = true;
            for (int i = 0; i < movies.Count; i++)
            {
                if (takes)
                {
                    takeTries--;
                    selectedMovies.Add(movies[i]);
                    if (takeTries == 0)
                    {
                        takes = !takes;
                        takeTries = -monthNumber;
                        continue;
                    }
                    continue;
                }
                takeTries++;
                if (takeTries == 0)
                {
                    takes = !takes;
                    takeTries = monthNumber;
                }
            }
            return selectedMovies;
        }

        public void GenerateTrainingPredictedGenre(int year, int month)
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            List<Person> directors = _dalContext.Persons.GetAllPersonsByProfession("director");
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            Random random = new();
            List<PredictedGenre> predictedGenres = new();
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            List<UserMovieSearch> movieSearches = _dalContext.UserMovieSearches
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            Tuple<string, string> searchesGenres = GetAverageGenres(movieSearches.Select(s => s.Movie).ToList(), genres);
            Tuple<string, string> seenMoviesGenres = GetAverageGenres(seenMovies.Select(s => s.Movie).ToList(), genres);
            Tuple<string, string> watchLaterMoviesGenres = GetAverageGenres(watchLaterMovies.Select(s => s.Movie).ToList(), genres);
            decimal averageUsersRating = Math.Round(GetAverageUsersRating(), 2);
            foreach (UserProfile userProfile in userProfiles)
            {
                decimal averageUserRating = Math.Round(GetAverageUserRating(userProfile.UserGUID), 2);
                List<SeenMovie> userSeenMovies = seenMovies
                    .Where(w => w.UserGUID == userProfile.UserGUID)
                    .ToList();
                List<MovieSubscription> userWatchLaterMovies = watchLaterMovies
                    .Where(w => w.UserGUID == userProfile.UserGUID)
                    .ToList();
                List<UserMovieSearch> userMovieSearches = movieSearches
                    .Where(w => w.UserGUID == userProfile.UserGUID)
                    .ToList();

                for (int i = 0; i < 80; i++)
                {
                    try
                    {
                        string globalGenre = "";
                        string globalGenre2 = "";
                        string myAverageGenre = "";
                        string myAverageGenre2 = "";
                        int module4 = i % 4;
                        int module2 = i % 2;
                        Tuple<string, string> myUserSearchesGenres = GetAverageGenres(userMovieSearches.Select(s => s.Movie).ToList(), genres);
                        Tuple<string, string> mySeenMovieGenres = GetAverageGenres(userSeenMovies.Select(s => s.Movie).ToList(), genres);
                        Tuple<string, string> myWatchLaterMoviesGenres = GetAverageGenres(userWatchLaterMovies.Select(s => s.Movie).ToList(), genres);
                        switch (module4)
                        {
                            case 0:
                                {
                                    myAverageGenre = myUserSearchesGenres.Item1 ?? genres[random.Next() % genres.Count];
                                    myAverageGenre2 = myUserSearchesGenres.Item2 ?? genres[random.Next() % genres.Count];
                                    globalGenre = searchesGenres.Item1 ?? genres[random.Next() % genres.Count];
                                    globalGenre2 = searchesGenres.Item2 ?? genres[random.Next() % genres.Count];
                                    break;
                                }
                            case 1:
                                {

                                    myAverageGenre = mySeenMovieGenres.Item1 ?? genres[random.Next() % genres.Count];
                                    myAverageGenre2 = mySeenMovieGenres.Item2 ?? genres[random.Next() % genres.Count];
                                    globalGenre = seenMoviesGenres.Item1 ?? genres[random.Next() % genres.Count];
                                    globalGenre2 = seenMoviesGenres.Item2 ?? genres[random.Next() % genres.Count];
                                    break;
                                }
                            case 2:
                                {

                                    myAverageGenre = myWatchLaterMoviesGenres.Item1 ?? genres[random.Next() % genres.Count];
                                    myAverageGenre2 = myWatchLaterMoviesGenres.Item2 ?? genres[random.Next() % genres.Count];
                                    globalGenre = watchLaterMoviesGenres.Item1 ?? genres[random.Next() % genres.Count];
                                    globalGenre2 = watchLaterMoviesGenres.Item2 ?? genres[random.Next() % genres.Count];
                                    break;
                                }
                            case 3:
                                {
                                    myAverageGenre = genres[random.Next(genres.Count) % genres.Count];
                                    myAverageGenre2 = genres[random.Next(genres.Count) % genres.Count];
                                    globalGenre = genres[random.Next() % genres.Count];
                                    globalGenre2 = genres[random.Next() % genres.Count];
                                    break;
                                }
                        }
                        string avg1 = GetAverageGenres(seenMovies.Select(s => s.Movie).ToList(), genres).Item1;
                        int averageGenreIndex = genres.IndexOf(avg1);
                        averageGenreIndex += random.Next(0, genres.Count) % genres.Count;
                        PredictedGenre predictedGenre = new();
                        if (i % 3 == 0)
                        {
                            predictedGenre = new()
                            {
                                UserId = userProfile.UserGUID,
                                AverageGenre1 = myAverageGenre,
                                AverageGenre2 = myAverageGenre2,
                                MyAverageGenre1 = globalGenre,
                                MyAverageGenre2 = globalGenre2,
                                AverageDirector = directors[random.Next(directors.Count)].Name,
                                MyAverageDirector = directors[random.Next(directors.Count)].Name,
                                Clicks = userMovieSearches.Count + random.Next(50, 100),
                                AverageRating = averageUsersRating,
                                MyAverageRating = averageUserRating,
                                FuturePredictedGenre = genres[(averageGenreIndex + random.Next(genres.Count)) % genres.Count]
                            };
                        }
                        else
                        {
                            predictedGenre = new()
                            {
                                UserId = userProfile.UserGUID,
                                AverageGenre1 = myAverageGenre,
                                AverageGenre2 = myAverageGenre2,
                                MyAverageGenre1 = globalGenre,
                                MyAverageGenre2 = globalGenre2,
                                AverageDirector = directors[random.Next(directors.Count)].Name,
                                MyAverageDirector = directors[random.Next(directors.Count)].Name,
                                Clicks = userMovieSearches.Count + random.Next(50, 100),
                                AverageRating = averageUsersRating,
                                MyAverageRating = averageUserRating,
                                FuturePredictedGenre = globalGenre
                            };
                        }
                        predictedGenres.Add(predictedGenre);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            string fileName = "Files\\Training\\genres.csv";
            ICSVHandlerService cSVWriterService = new CSVHandlerService(fileName);
            if (new FileInfo(fileName).Length == 0)
            {
                cSVWriterService.WriteCSV(predictedGenres);
                return;
            }
            cSVWriterService.AppendCSV(predictedGenres);
        }

        public void GenerateTrainingPredictedMovieRuntime(int year, int month)
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            List<UserMovieSearch> movieSearches = _dalContext.UserMovieSearches
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            Random random = new();
            decimal averageUsersRating = Math.Round(GetAverageUsersRating(), 2);
            List<PredictedMovieRuntime> predictingMovieRuntimes = new();
            foreach (UserProfile userProfile in userProfiles)
            {
                try
                {
                    decimal averageUserRating = Math.Round(GetAverageUserRating(userProfile.UserGUID), 2);
                    List<MovieSubscription> userWatchLaterMovies = watchLaterMovies
                        .Where(w => w.UserGUID == userProfile.UserGUID)
                        .ToList();
                    List<SeenMovie> userSeenMovies = seenMovies
                        .Where(w => w.UserGUID == userProfile.UserGUID)
                        .ToList();
                    List<UserMovieSearch> userMovieSearches = movieSearches
                        .Where(w => w.UserGUID == userProfile.UserGUID)
                        .ToList();
                    for (int i = 0; i < 80; i++)
                    {
                        PredictedMovieRuntime predictingMovieRuntime = new();
                        if (i % 2 == 0)
                        {
                            int myAverageWatchLaterMovieRuntime = userWatchLaterMovies.Select(u => u.Movie.Runtime).Sum() + random.Next(10, 30);
                            int myAverageSeenMoviesRuntime = userSeenMovies.Select(u => u.Movie.Runtime).Sum() + random.Next(10, 30);
                            predictingMovieRuntime = new()
                            {
                                UserId = userProfile.UserGUID,
                                AverageRuntime = seenMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(10, 30),
                                MyAverageRuntime = myAverageSeenMoviesRuntime,
                                AverageMovieClicks = movieSearches.Count / userProfiles.Count + random.Next(10, 30),
                                MyMovieClicks = userMovieSearches.Count + random.Next(10, 30),
                                AverageWatchLaterMoviesRuntime = watchLaterMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(10, 30),
                                MyAverageWatchLaterMoviesRuntime = myAverageWatchLaterMovieRuntime,
                                AverageRating = averageUsersRating,
                                MyAverageRating = averageUserRating,
                                FuturePredictedRuntime = (myAverageWatchLaterMovieRuntime + myAverageSeenMoviesRuntime) / 2 + random.Next(10, 30),
                            };
                        }
                        else
                        {
                            int myAverageWatchLaterMovieRuntime = Math.Abs(userWatchLaterMovies.Select(u => u.Movie.Runtime).Sum() - random.Next(10, 30));
                            int myAverageSeenMoviesRuntime = Math.Abs(userSeenMovies.Select(u => u.Movie.Runtime).Sum() - random.Next(10, 30));
                            predictingMovieRuntime = new()
                            {
                                UserId = userProfile.UserGUID,
                                AverageRuntime = Math.Abs(seenMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count - random.Next(10, 30)),
                                MyAverageRuntime = myAverageSeenMoviesRuntime,
                                AverageMovieClicks = Math.Abs(movieSearches.Count / userProfiles.Count - random.Next(10, 30)),
                                MyMovieClicks = Math.Abs(userMovieSearches.Count + random.Next(10, 30)),
                                AverageWatchLaterMoviesRuntime = Math.Abs(watchLaterMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count - random.Next(10, 30)),
                                MyAverageWatchLaterMoviesRuntime = myAverageWatchLaterMovieRuntime,
                                AverageRating = averageUsersRating,
                                MyAverageRating = averageUserRating,
                                FuturePredictedRuntime = Math.Abs((myAverageWatchLaterMovieRuntime + myAverageSeenMoviesRuntime) / 2 - random.Next(10, 30)),
                            };
                        }
                        predictingMovieRuntimes.Add(predictingMovieRuntime);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            string fileName = "Files\\Training\\movieRuntime.csv";
            ICSVHandlerService cSVWriterService = new CSVHandlerService(fileName);
            if (new FileInfo(fileName).Length == 0)
            {
                cSVWriterService.WriteCSV(predictingMovieRuntimes);
                return;
            }
            cSVWriterService.AppendCSV(predictingMovieRuntimes);
        }

        public void GenerateTrainingPredictedMovieCount(int year, int month)
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies
            .GetAll()
            .Where(s => s.CreatedAt.Year == year &&
                        s.CreatedAt.Month == month)
            .ToList();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            List<UserMovieSearch> movieSearches = _dalContext.UserMovieSearches
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            Random random = new();
            List<PredictedMovieCount> predictedMovieCounts = new();
            int k = 0;
            decimal averageUsersRating = Math.Round(GetAverageUsersRating(), 2);
            foreach (UserProfile userProfile in userProfiles)
            {
                List<MovieSubscription> userWatchLaterMovies = watchLaterMovies.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                List<SeenMovie> userSeenMovies = seenMovies.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                List<UserMovieSearch> userMovieSearches = movieSearches.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                decimal averageUserRating = Math.Round(GetAverageUserRating(userProfile.UserGUID), 2);
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        PredictedMovieCount predictedMovieCount = new();
                        if (i % 2 == 0)
                        {
                            int myAverageWatchLaterMoviesCount = userWatchLaterMovies.Count + random.Next(8, 15);
                            int myAverageSeenMoviesCount = userSeenMovies.Count + random.Next(8, 15);
                            predictedMovieCount = new()
                            {
                                UserId = userProfile.UserGUID,
                                AverageMovieCount = seenMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(8, 15),
                                MyAverageMovieCount = myAverageSeenMoviesCount,
                                AverageWatchLaterMovies = watchLaterMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(8, 15),
                                MyAverageWatchLaterMovies = myAverageWatchLaterMoviesCount,
                                AverageMovieClicks = movieSearches.Count / userProfiles.Count + random.Next(8, 15),
                                MyMovieClicks = userMovieSearches.Count + random.Next(8, 15),
                                AverageRating = averageUsersRating,
                                MyAverageRating = averageUserRating,
                                FuturePredictedMovieCount = (myAverageWatchLaterMoviesCount + myAverageSeenMoviesCount) / 2 + random.Next(8, 15)
                            };
                            predictedMovieCounts.Add(predictedMovieCount);
                            continue;
                        }
                        else
                        {
                            int myAverageWatchLaterMoviesCount = Math.Abs(userWatchLaterMovies.Count - random.Next(8, 15));
                            int myAverageSeenMoviesCount = Math.Abs(userSeenMovies.Count - random.Next(8, 15));
                            predictedMovieCount = new()
                            {
                                UserId = userProfile.UserGUID,
                                AverageMovieCount = Math.Abs(seenMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count - random.Next(8, 15)),
                                MyAverageMovieCount = myAverageSeenMoviesCount,
                                AverageWatchLaterMovies = Math.Abs(watchLaterMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count - random.Next(8, 15)),
                                MyAverageWatchLaterMovies = myAverageWatchLaterMoviesCount,
                                AverageMovieClicks = Math.Abs(movieSearches.Count / userProfiles.Count - random.Next(8, 15)),
                                MyMovieClicks = Math.Abs(userMovieSearches.Count - random.Next(8, 15)),
                                AverageRating = averageUsersRating,
                                MyAverageRating = averageUserRating,
                                FuturePredictedMovieCount = Math.Abs((myAverageWatchLaterMoviesCount + myAverageSeenMoviesCount) / 2 - random.Next(8, 15))
                            };
                            predictedMovieCounts.Add(predictedMovieCount);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            string fileName = "Files\\Training\\movieCount.csv";
            ICSVHandlerService cSVWriterService = new CSVHandlerService(fileName);
            if (new FileInfo(fileName).Length == 0)
            {
                cSVWriterService.WriteCSV(predictedMovieCounts);
                return;
            }
            cSVWriterService.AppendCSV(predictedMovieCounts);
        }

        public void GenerateTrainingPredictedAgesViewership(int year, int month)
        {
            Random random = new();
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<PredictedAgeViewership> predictedAgeViewerships = new();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies
           .GetAll()
           .Where(s => s.CreatedAt.Year == year &&
                       s.CreatedAt.Month == month)
           .ToList();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            List<UserMovieSearch> movieSearches = _dalContext.UserMovieSearches
                .GetAll()
                .Where(s => s.CreatedAt.Year == year &&
                            s.CreatedAt.Month == month)
                .ToList();
            for (int age = 15; age < 60; age++)
            {
                for (int i = 0; i < 30; i++)
                {
                    try
                    {
                        List<UserProfile> profiles = _dalContext
                         .UserProfiles
                         .GetAll()
                         .Where(u => CalculateAge(u.DateOfBirth) == age)
                         .ToList();
                        if (profiles.Count != 0)
                        {
                            int seenMoviesCount = 0;
                            int watchLaterMoviesCount = 0;
                            int clicksByAge = 0;
                            foreach (UserProfile profile in profiles)
                            {
                                List<UserMovieSearch> userMovieSearches = movieSearches.Where(w => w.UserGUID == profile.UserGUID).ToList();
                                seenMoviesCount += seenMovies.Where(s => s.UserGUID == profile.UserGUID).ToList().Count;
                                watchLaterMoviesCount += watchLaterMovies.Where(s => s.UserGUID == profile.UserGUID).ToList().Count;
                                clicksByAge += userMovieSearches.Where(s => s.UserGUID == profile.UserGUID).ToList().Count;
                            }
                            int averageSeenMovieCount = seenMoviesCount / profiles.Count;
                            int averageWatchLaterMoviesCount = watchLaterMoviesCount / profiles.Count;
                            PredictedAgeViewership predictedAgeViewership = new();
                            if (i % 2 == 0)
                            {
                                predictedAgeViewership = new()
                                {
                                    Age = age,
                                    WatchLaterMoviesByAge = averageSeenMovieCount + random.Next(4, 9),
                                    SeenMoviesByAge = averageWatchLaterMoviesCount + random.Next(4, 9),
                                    ClicksByAge = clicksByAge + random.Next(20, 50),
                                    FuturePredictedMoviesCount = (averageSeenMovieCount + averageWatchLaterMoviesCount) / 2 + random.Next(4, 9),
                                };
                            }
                            else
                            {
                                predictedAgeViewership = new()
                                {
                                    Age = age,
                                    WatchLaterMoviesByAge = Math.Abs(averageSeenMovieCount - random.Next(4, 9)),
                                    SeenMoviesByAge = Math.Abs(averageWatchLaterMoviesCount - random.Next(4, 9)),
                                    ClicksByAge = Math.Abs(clicksByAge - random.Next(20, 50)),
                                    FuturePredictedMoviesCount = Math.Abs((averageSeenMovieCount = averageWatchLaterMoviesCount) / 2 - random.Next(4, 9)),
                                };
                            }

                            predictedAgeViewerships.Add(predictedAgeViewership);
                            continue;
                        }
                        int averageSeenMoviesNow = predictedAgeViewerships.Select(p => p.SeenMoviesByAge).Sum() / predictedAgeViewerships.Count;
                        int averageWatchLaterMoviesNow = predictedAgeViewerships.Select(p => p.WatchLaterMoviesByAge).Sum() / predictedAgeViewerships.Count;
                        int averageClicksUntilNow = predictedAgeViewerships.Select(p => p.ClicksByAge).Sum() / predictedAgeViewerships.Count;
                        if (i % 2 == 0)
                        {
                            predictedAgeViewerships.Add(new()
                            {
                                Age = age,
                                WatchLaterMoviesByAge = averageWatchLaterMoviesNow + random.Next(4, 9),
                                SeenMoviesByAge = averageSeenMoviesNow + random.Next(4, 9),
                                ClicksByAge = averageClicksUntilNow + random.Next(20, 50),
                                FuturePredictedMoviesCount = (averageSeenMoviesNow + averageWatchLaterMoviesNow) / 2 + random.Next(4, 9),
                            });
                        }
                        else
                        {
                            predictedAgeViewerships.Add(new()
                            {
                                Age = Math.Abs(age),
                                WatchLaterMoviesByAge = Math.Abs(averageWatchLaterMoviesNow - random.Next(4, 9)),
                                SeenMoviesByAge = Math.Abs(averageSeenMoviesNow - random.Next(4, 9)),
                                ClicksByAge = Math.Abs(averageClicksUntilNow - random.Next(20, 50)),
                                FuturePredictedMoviesCount = Math.Abs((averageSeenMoviesNow + averageWatchLaterMoviesNow) / 2 - random.Next(4, 9)),
                            });
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            string fileName = "Files\\Training\\ageViewership.csv";
            ICSVHandlerService cSVWriterService = new CSVHandlerService(fileName);
            if (new FileInfo(fileName).Length == 0)
            {
                cSVWriterService.WriteCSV(predictedAgeViewerships);
                return;
            }
            cSVWriterService.AppendCSV(predictedAgeViewerships);
        }

        public void GenerateTrainingPredictedMovies(int year, int month)
        {
            Random random = new();
            List<PredictedMovie> predictedMovies = new();
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            int numberOfRecommendedMonths = 3;
            int numberOfRecommendationsPerMonth = 30;
            List<DAL.Models.MachineLearning.PredictedGenre> predictedGenres = _dalContext.PredictedGenres
                                                                                     .GetAll()
                                                                                     .ToList();
            List<Movie> movies = _dalContext.Movies.GetAll();
            for (int i = 0; i < numberOfRecommendedMonths; i++)
            {
                List<Movie> randomGeneratedMovies = GetRandomGeneratedMovies(movies, i + 1);
                foreach (ApplicationUser user in users)
                {
                    UserProfile? userProfile = _dalContext.UserProfiles.GetByUserGuid(user.Id);
                    if (userProfile == null)
                    {
                        continue;
                    }
                    decimal averageUsersRating = Math.Round(GetAverageUsersRating(), 2);
                    decimal averageUserRating = Math.Round(GetAverageUserRating(userProfile.UserGUID), 2);
                    int age = CalculateAge(userProfile.DateOfBirth);
                    List<Movie> intialSeenMovies = _dalContext.SeenMovies
                        .GetAllByUser(user.Id)
                        .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                        .Select(s => s.Movie)
                        .ToList();
                    List<Movie> concatedSeenMovies = _dalContext.SeenMovies
                        .GetAllByUser(user.Id)
                        .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                        .Select(s => s.Movie)
                        .Concat(randomGeneratedMovies)
                        .ToList();
                    List<Movie> watchLaterMovies = _dalContext.MovieSubscriptions
                        .GetAllByUser(user.Id)
                        .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                        .Select(s => s.Movie)
                        .Concat(randomGeneratedMovies)
                        .ToList();
                    List<Movie> likedMovies = _dalContext.LikedMovies
                        .GetAllByUser(user.Id)
                        .Where(s => s.CreatedAt.Year == year && s.CreatedAt.Month == month)
                        .Select(s => s.Movie).Concat(randomGeneratedMovies)
                        .ToList();
                    List<Movie> collectionMovies = _dalContext.Movies
                        .GetMoviesCollection(user.Id)
                        .Concat(randomGeneratedMovies)
                        .ToList();
                    List<DAL.Models.MachineLearning.PredictedGenre> userPredictedGenres = predictedGenres
                                                                                            .Where(p => p.UserGUID == user.Id)
                                                                                            .ToList();
                    string mostWatchedGenre = GetMostWatchedGenre(intialSeenMovies);
                    string mostWatchedMovie = GetMostWatchedMovie(intialSeenMovies);

                    for (int j = 0; j < numberOfRecommendationsPerMonth; j++)
                    {
                        int currentIndex = i * numberOfRecommendationsPerMonth + j;
                        string predictedGenre = userPredictedGenres[random.Next(0, userPredictedGenres.Count)].Genre;
                        if (predictedGenre == "SciFi")
                        {
                            predictedGenre = "Sci-Fi";
                        }
                        if (predictedGenre == "FilmNoir")
                        {
                            predictedGenre = "Film-Noir";
                        }
                        try
                        {
                            List<Movie> futurePredictedMovies = movies
                                .Where(m => m.Genres.Split(',')
                                .Contains(predictedGenre))
                                .ToList();
                            string futurePredictedMovie = futurePredictedMovies[random.Next(0, futurePredictedMovies.Count) % futurePredictedMovies.Count].Title;
                            if (j % 3 == 0)
                            {
                                try
                                {
                                    predictedMovies.Add(new()
                                    {
                                        UserEmail = user.Email,
                                        WatchLaterMovie = watchLaterMovies[currentIndex].Title,
                                        LikedMovie = likedMovies[currentIndex].Title,
                                        CollectionMovie = collectionMovies[currentIndex].Title,
                                        Age = age,
                                        City = userProfile.City,
                                        MostWatchedGenre = mostWatchedGenre,
                                        MostWatchedMovie = mostWatchedMovie,
                                        AverageRating = averageUsersRating,
                                        MyAverageRating = averageUserRating,
                                        PredictedGenre = predictedGenre,
                                        FuturePredictedMovie = futurePredictedMovie
                                    });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    continue;
                                }
                            }
                            else
                            {
                                try
                                {
                                    predictedMovies.Add(new()
                                    {
                                        UserEmail = user.Email,
                                        WatchLaterMovie = watchLaterMovies[currentIndex].Title,
                                        LikedMovie = concatedSeenMovies[random.Next(concatedSeenMovies.Count)].Title,
                                        CollectionMovie = concatedSeenMovies[random.Next(concatedSeenMovies.Count)].Title,
                                        Age = age,
                                        City = userProfile.City,
                                        MostWatchedGenre = concatedSeenMovies[random.Next(concatedSeenMovies.Count)].Title,
                                        MostWatchedMovie = concatedSeenMovies[random.Next(concatedSeenMovies.Count)].Title,
                                        AverageRating = averageUsersRating,
                                        MyAverageRating = averageUserRating,
                                        PredictedGenre = predictedGenre,
                                        FuturePredictedMovie = concatedSeenMovies[random.Next(concatedSeenMovies.Count)].Title
                                    });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    continue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            string filename = "Files\\Training\\predictedMovie.csv";
            ICSVHandlerService cSVWriterService = new CSVHandlerService(filename);
            if (new FileInfo(filename).Length == 0)
            {
                cSVWriterService.WriteCSV(predictedMovies);
                return;
            }
            cSVWriterService.AppendCSV(predictedMovies);
        }
    }
}