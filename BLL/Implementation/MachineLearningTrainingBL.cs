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

        private Tuple<string, string> GetAverageGenres(List<Movie> movies, List<string> genres)
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

        public void GenerateTrainingPredictedGenre()
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll();
            List<Person> directors = _dalContext.Persons.GetAllPersonsByProfession("director");
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            Random random = new();
            List<PredictedGenre> predictedGenres = new();
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<PredictedAgeViewership> predictedAgeViewerships = new();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies.GetAll();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions.GetAll();
            List<UserMovieSearch> movieSearches = _dalContext.UserMovieSearches.GetAll();
            foreach (UserProfile userProfile in userProfiles)
            {
                List<SeenMovie> userSeenMovies = seenMovies
                    .Where(w => w.UserGUID == userProfile.UserGUID)
                    .ToList();
                List<MovieSubscription> userWatchLaterMovies = watchLaterMovies
                    .Where(w => w.UserGUID == userProfile.UserGUID)
                    .ToList();
                List<UserMovieSearch> userMovieSearches = movieSearches
                    .Where(w => w.UserGUID == userProfile.UserGUID)
                    .ToList();

                for (int i = 0; i < 400; i++)
                {
                    try
                    {
                        string averageGenre = "";
                        int module4 = i % 4;
                        int module2 = i % 2;
                        switch (module4)
                        {
                            case 0:
                                {
                                    Tuple<string, string> myGenres = GetAverageGenres(userMovieSearches.Select(s => s.Movie).ToList(), genres);
                                    if (module2 == 0)
                                    {
                                        averageGenre = myGenres.Item1;
                                    }
                                    else
                                    {
                                        averageGenre = myGenres.Item2;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    Tuple<string, string> myGenres = GetAverageGenres(userMovieSearches.Select(s => s.Movie).ToList(), genres);
                                    if (module2 == 0)
                                    {
                                        averageGenre = myGenres.Item1;
                                    }
                                    else
                                    {
                                        averageGenre = myGenres.Item2;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Tuple<string, string> myGenres = GetAverageGenres(userSeenMovies.Select(s => s.Movie).ToList(), genres);
                                    if (module2 == 0)
                                    {
                                        averageGenre = myGenres.Item1;
                                    }
                                    else
                                    {
                                        averageGenre = myGenres.Item2;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    averageGenre = genres[random.Next(genres.Count)];
                                    break;
                                }
                        }
                        string avg1 = GetAverageGenres(seenMovies.Select(s => s.Movie).ToList(), genres).Item1;
                        int averageGenreIndex = genres.IndexOf(avg1);
                        averageGenreIndex += random.Next(0, genres.Count) % genres.Count;
                        PredictedGenre predictedGenre = new()
                        {
                            UserId = userProfile.UserGUID,
                            AverageGenre1 = averageGenre,
                            AverageGenre2 = genres[averageGenreIndex],
                            MyAverageGenre1 = genres[random.Next(averageGenreIndex) % genres.Count],
                            MyAverageGenre2 = genres[random.Next(genres.IndexOf(GetAverageGenres(userSeenMovies.Select(s => s.Movie).ToList(), genres).Item1)) % genres.Count],
                            AverageDirector = directors[random.Next(directors.Count)].Name,
                            MyAverageDirector = directors[random.Next(directors.Count)].Name,
                            Clicks = userMovieSearches.Count + random.Next(50, 100),
                            FuturePredictedGenre = genres[(averageGenreIndex + random.Next(genres.Count)) % genres.Count]
                        };
                        predictedGenres.Add(predictedGenre);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\genres.csv");
            cSVWriterService.WriteCSV(predictedGenres);
        }

        public void GenerateTrainingPredictedMovieCount()
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<PredictedAgeViewership> predictedAgeViewerships = new();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies.GetAll();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions.GetAll();
            List<UserMovieSearch> movieSearches = _dalContext.UserMovieSearches.GetAll();
            Random random = new();
            List<PredictedMovieCount> predictedMovieCounts = new();
            int k = 0;
            foreach (UserProfile userProfile in userProfiles)
            {
                List<MovieSubscription> userWatchLaterMovies = watchLaterMovies.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                List<SeenMovie> userSeenMovies = seenMovies.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                List<UserMovieSearch> userMovieSearches = movieSearches.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                for (int i = 0; i < 400; i++)
                {
                    try
                    {
                        int myAverageWatchLaterMoviesCount = userWatchLaterMovies.Count + random.Next(0, 100);
                        int myAverageSeenMoviesCount = userSeenMovies.Count + random.Next(0, 100);
                        PredictedMovieCount predictedMovieCount = new()
                        {
                            UserId = userProfile.UserGUID,
                            AverageMovieCount = seenMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(0, 100),
                            MyAverageMovieCount = myAverageSeenMoviesCount,
                            AverageWatchLaterMovies = watchLaterMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(0, 100),
                            MyAverageWatchLaterMovies = myAverageWatchLaterMoviesCount,
                            AverageMovieClicks = movieSearches.Count / userProfiles.Count + random.Next(0, 100),
                            MyMovieClicks = userMovieSearches.Count + random.Next(0, 100),
                            FuturePredictedMovieCount = (myAverageWatchLaterMoviesCount + myAverageSeenMoviesCount) / 2 + random.Next(0, 100)
                        };
                        predictedMovieCounts.Add(predictedMovieCount);
                        Console.WriteLine(k);
                        k++;
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\movieCount.csv");
            cSVWriterService.WriteCSV(predictedMovieCounts);
        }

        public void GenerateTrainingPredictedMovieRuntime()
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<PredictedAgeViewership> predictedAgeViewerships = new();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies.GetAll();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions.GetAll();
            List<UserMovieSearch> movieSearches = _dalContext.UserMovieSearches.GetAll();
            Random random = new();
            List<PredictedMovieRuntime> predictingMovieRuntimes = new();
            foreach (UserProfile userProfile in userProfiles)
            {
                try
                {
                    List<MovieSubscription> userWatchLaterMovies = watchLaterMovies.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                    List<SeenMovie> userSeenMovies = seenMovies.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                    List<UserMovieSearch> userMovieSearches = movieSearches.Where(w => w.UserGUID == userProfile.UserGUID).ToList();
                    for (int i = 0; i < 400; i++)
                    {
                        int myAverageWatchLaterMovieRuntime = userWatchLaterMovies.Select(u => u.Movie.Runtime).Sum() + random.Next(0, 100);
                        int myAverageSeenMoviesRuntime = userSeenMovies.Select(u => u.Movie.Runtime).Sum() + random.Next(0, 100);
                        PredictedMovieRuntime predictingMovieRuntime = new()
                        {
                            UserId = userProfile.UserGUID,
                            AverageRuntime = seenMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(0, 100),
                            MyAverageRuntime = myAverageSeenMoviesRuntime,
                            AverageMovieClicks = movieSearches.Count / userProfiles.Count + random.Next(0, 100),
                            MyMovieClicks = userMovieSearches.Count + random.Next(0, 100),
                            AverageWatchLaterMoviesRuntime = watchLaterMovies.Select(u => u.Movie.Runtime).Sum() / userProfiles.Count + random.Next(0, 100),
                            MyAverageWatchLaterMoviesRuntime = myAverageWatchLaterMovieRuntime,
                            FuturePredictedRuntime = (myAverageWatchLaterMovieRuntime + myAverageSeenMoviesRuntime) / 2 + random.Next(0, 100)
                        };
                        predictingMovieRuntimes.Add(predictingMovieRuntime);
                    }
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\movieRuntime.csv");
            cSVWriterService.WriteCSV(predictingMovieRuntimes);
        }

        public void GenerateTrainingPredictedAgesViewership()
        {
            Random random = new();
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<PredictedAgeViewership> predictedAgeViewerships = new();
            List<SeenMovie> seenMovies = _dalContext.SeenMovies.GetAll();
            List<MovieSubscription> watchLaterMovies = _dalContext.MovieSubscriptions.GetAll();
            List<UserMovieSearch> userMovieSearches = _dalContext.UserMovieSearches.GetAll();
            for (int age = 15; age < 80; age++)
            {
                for (int i = 0; i < 100; i++)
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
                                seenMoviesCount += seenMovies.Where(s => s.UserGUID == profile.UserGUID).ToList().Count;
                                watchLaterMoviesCount += watchLaterMovies.Where(s => s.UserGUID == profile.UserGUID).ToList().Count;
                                clicksByAge += userMovieSearches.Where(s => s.UserGUID == profile.UserGUID).ToList().Count;
                            }
                            int averageSeenMovieCount = seenMoviesCount / profiles.Count;
                            int averageWatchLaterMoviesCount = watchLaterMoviesCount / profiles.Count;

                            PredictedAgeViewership predictedAgeViewership = new()
                            {
                                Age = age,
                                WatchLaterMoviesByAge = averageSeenMovieCount + random.Next(50, 100),
                                SeenMoviesByAge = averageWatchLaterMoviesCount + random.Next(50, 100),
                                ClicksByAge = clicksByAge + random.Next(50, 100),
                                FuturePredictedMoviesCount = (averageSeenMovieCount + averageWatchLaterMoviesCount) / 2 + random.Next(50, 100),
                            };
                            predictedAgeViewerships.Add(predictedAgeViewership);
                        }
                        int averageSeenMoviesNow = predictedAgeViewerships.Select(p => p.SeenMoviesByAge).Sum() / predictedAgeViewerships.Count;
                        int averageWatchLaterMoviesNow = predictedAgeViewerships.Select(p => p.WatchLaterMoviesByAge).Sum() / predictedAgeViewerships.Count;
                        int averageClicksUntilNow = predictedAgeViewerships.Select(p => p.ClicksByAge).Sum() / predictedAgeViewerships.Count;
                        predictedAgeViewerships.Add(new()
                        {
                            Age = age + random.Next(5, 10),
                            WatchLaterMoviesByAge = averageWatchLaterMoviesNow + random.Next(50, 100),
                            SeenMoviesByAge = averageSeenMoviesNow + random.Next(50, 100),
                            ClicksByAge = averageClicksUntilNow + random.Next(50, 100),
                            FuturePredictedMoviesCount = (averageSeenMoviesNow + averageWatchLaterMoviesNow) / 2 + random.Next(50, 100),
                        });
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\ageViewership.csv");
            cSVWriterService.WriteCSV(predictedAgeViewerships);
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

        public void GenerateTrainingPredictedMovies()
        {
            Random random = new();
            List<PredictedMovie> predictedMovies = new();
            List<ApplicationUser> users = _dalContext.Users.GetAll()!;
            int numberOfRecommendedMonths = 6;
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
                    int age = CalculateAge(userProfile.DateOfBirth);
                    List<Movie> intialSeenMovies = _dalContext.SeenMovies.GetAllByUser(user.Id).Select(s => s.Movie).ToList();
                    List<Movie> concatedSeenMovies = _dalContext.SeenMovies.GetAllByUser(user.Id).Select(s => s.Movie).Concat(randomGeneratedMovies).ToList();
                    List<Movie> watchLaterMovies = _dalContext.MovieSubscriptions.GetAllByUser(user.Id).Select(s => s.Movie).Concat(randomGeneratedMovies).ToList();
                    List<Movie> likedMovies = _dalContext.LikedMovies.GetAllByUser(user.Id).Select(s => s.Movie).Concat(randomGeneratedMovies).ToList();
                    List<Movie> collectionMovies = _dalContext.Movies.GetMoviesCollection(user.Id).Concat(randomGeneratedMovies).ToList();
                    List<DAL.Models.MachineLearning.PredictedGenre> userPredictedGenres = predictedGenres
                                                                                            .Where(p => p.UserGUID == user.Id)
                                                                                            .ToList();
                    string mostWatchedGenre = GetMostWatchedGenre(intialSeenMovies);
                    string mostWatchedMovie = GetMostWatchedMovie(intialSeenMovies);

                    for (int j = 0; j < numberOfRecommendationsPerMonth; j++)
                    {
                        //string seenMoviesList = "";
                        //string watchLaterMoviesList = "";
                        //string likedMoviesList = "";
                        //string collectionMoviesList = "";
                        //for (int k = 0; k < numberOfIterationsPerRecommendation; k++)
                        //{
                        //    int currentIndex = i * numberOfRecommendationsPerMonth * numberOfIterationsPerRecommendation + j * numberOfIterationsPerRecommendation + k;
                        //    seenMoviesList += concatedSeenMovies[currentIndex % concatedSeenMovies.Count].Title;
                        //    watchLaterMoviesList += watchLaterMovies[currentIndex % watchLaterMovies.Count].Title;
                        //    likedMoviesList += likedMovies[currentIndex % likedMovies.Count].Title;
                        //    collectionMoviesList += collectionMovies[currentIndex % collectionMovies.Count].Title;
                        //    if (k != numberOfIterationsPerRecommendation - 1)
                        //    {
                        //        seenMoviesList += ";";
                        //        watchLaterMoviesList += ";";
                        //        likedMoviesList += ";";
                        //        collectionMoviesList += ";";
                        //    }
                        //}
                        int currentIndex = i * numberOfRecommendationsPerMonth + j;
                        //string predictedGenre = userPredictedGenres.Last().Genre;
                        string predictedGenre = userPredictedGenres[random.Next(0, userPredictedGenres.Count)].Genre;
                        if (predictedGenre == "SciFi")
                        {
                            predictedGenre = "Sci-Fi";
                        }
                        if (predictedGenre == "FilmNoir")
                        {
                            predictedGenre = "Film-Noir";
                        }
                        List<Movie> futurePredictedMovies = movies.Where(m => m.Genres.Split(',').Contains(predictedGenre)).ToList();
                        string futurePredictedMovie = futurePredictedMovies[random.Next(0, futurePredictedMovies.Count)].Title;
                        //predictedMovies.Add(new()
                        //{
                        //    UserId = user.Id,
                        //    SeenMovie = seenMoviesList,
                        //    WatchLaterMovie = watchLaterMoviesList,
                        //    LikedMovie = likedMoviesList,
                        //    CollectionMovie = collectionMoviesList,
                        //    Age = age,
                        //    City = userProfile.City,
                        //    MostWatchedGenre = mostWatchedGenre,
                        //    MostWatchedMovie = mostWatchedMovie,
                        //    PredictedGenre = predictedGenre,
                        //    FuturePredictedMovie = futurePredictedMovie
                        //});

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
                            PredictedGenre = predictedGenre,
                            FuturePredictedMovie = futurePredictedMovie
                        });
                    }
                }
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\predictedMovie.csv");
            cSVWriterService.WriteCSV(predictedMovies);
        }
    }
}