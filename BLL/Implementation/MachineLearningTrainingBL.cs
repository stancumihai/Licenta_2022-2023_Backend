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

        public void GenerateTrainingPredictedGenre()
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll();
            List<Person> directors = _dalContext.Persons.GetAllPersonsByProfession("director");
            List<string> genres = _dalContext.Movies.GetMovieGenres();
            Random random = new();
            List<PredictedGenre> predictedGenres = new();
            for (int i = 0; i < MAX_TRAINING_RECORDS; i++)
            {
                int userIndex = random.Next(users.Count);
                int directorIndex = random.Next(directors.Count);
                int myDirectorIndex = random.Next(directors.Count);
                int averageGenre1Index = random.Next(genres.Count);
                int averageGenre2Index = random.Next(genres.Count);
                int myAverageGenre1Index = random.Next(genres.Count);
                int myAverageGenre2Index = random.Next(genres.Count);
                int clicks = random.Next(1000);
                int futureGenreIndex = random.Next(genres.Count);
                PredictedGenre predictedGenre = new PredictedGenre
                {
                    UserId = users[userIndex].Id,
                    AverageGenre1 = genres[averageGenre1Index],
                    AverageGenre2 = genres[averageGenre2Index],
                    MyAverageGenre1 = genres[myAverageGenre1Index],
                    MyAverageGenre2 = genres[myAverageGenre2Index],
                    AverageDirector = directors[directorIndex].Name,
                    MyAverageDirector = directors[myDirectorIndex].Name,
                    Clicks = clicks,
                    FuturePredictedGenre = genres[futureGenreIndex]
                };
                predictedGenres.Add(predictedGenre);
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\genres.csv");
            cSVWriterService.WriteCSV(predictedGenres);
        }

        public void GenerateTrainingPredictedMovieCount()
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll();
            Random random = new();
            List<PredictedMovieCount> predictingMovieCounts = new();
            for (int i = 0; i < MAX_TRAINING_RECORDS; i++)
            {
                PredictedMovieCount predictingMovieCount = new PredictedMovieCount
                {
                    UserId = users[random.Next(users.Count)].Id,
                    AverageMovieCount = random.Next(100),
                    MyAverageMovieCount = random.Next(100),
                    AverageWatchLaterMovies = random.Next(100),
                    MyAverageWatchLaterMovies = random.Next(100),
                    AverageMovieClicks = random.Next(100),
                    MyMovieClicks = random.Next(100),
                    FuturePredictedMovieCount = random.Next(100)
                };
                predictingMovieCounts.Add(predictingMovieCount);
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\movieCount.csv");
            cSVWriterService.WriteCSV(predictingMovieCounts);
        }

        public void GenerateTrainingPredictedMovieRuntime()
        {
            List<ApplicationUser> users = _dalContext.Users.GetAll();
            Random random = new();
            List<PredictedMovieRuntime> predictingMovieRuntimes = new();
            for (int i = 0; i < MAX_TRAINING_RECORDS; i++)
            {
                PredictedMovieRuntime predictingMovieRuntime = new()
                {
                    UserId = users[random.Next(users.Count)].Id,
                    AverageRuntime = random.Next(1000),
                    MyAverageRuntime = random.Next(1000),
                    AverageMovieClicks = random.Next(100),
                    MyMovieClicks = random.Next(100),
                    AverageWatchLaterMoviesRuntime = random.Next(1000),
                    MyAverageWatchLaterMoviesRuntime = random.Next(1000),
                    FuturePredictedRuntime = random.Next(1000),
                };
                predictingMovieRuntimes.Add(predictingMovieRuntime);
            }
            ICSVHandlerService cSVWriterService = new CSVHandlerService("Files\\Training\\movieRuntime.csv");
            cSVWriterService.WriteCSV(predictingMovieRuntimes);
        }
        public void GenerateTrainingPredictedAgesViewership()
        {
            Random random = new();
            List<PredictedAgeViewership> predictedAgeViewerships = new();
            for (int i = 0; i < MAX_TRAINING_RECORDS; i++)
            {
                int seenMoviesByAgeCount = random.Next(200, 500);
                PredictedAgeViewership predictedAgeViewership = new()
                {
                    Age = random.Next(15, 60),
                    WatchLaterMoviesByAge = seenMoviesByAgeCount - 100,
                    SeenMoviesByAge = seenMoviesByAgeCount,
                    ClicksByAge = random.Next(seenMoviesByAgeCount, seenMoviesByAgeCount + 200),
                    FuturePredictedMoviesCount = random.Next(250, 550),
                };
                predictedAgeViewerships.Add(predictedAgeViewership);
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