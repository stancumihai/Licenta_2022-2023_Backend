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
            ICSVHandlerService cSVWriterService = new CSVHandlerServiceService("Files\\Training\\genres.csv");
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
            ICSVHandlerService cSVWriterService = new CSVHandlerServiceService("Files\\Training\\movieCount.csv");
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
            ICSVHandlerService cSVWriterService = new CSVHandlerServiceService("Files\\Training\\movieRuntime.csv");
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
            ICSVHandlerService cSVWriterService = new CSVHandlerServiceService("Files\\Training\\ageViewership.csv");
            cSVWriterService.WriteCSV(predictedAgeViewerships);
        }
    }
}