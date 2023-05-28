using BLL.Converters.PredictedAgeViewership;
using BLL.Core;
using BLL.Implementation.Mechanisms;
using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces.MachineLearning;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.MachineLearning;
using Library.Models._UI;
using Library.Models.PredictedAgeViewership;

namespace BLL.Implementation.MachineLearning
{
    public class PredictedAgesViewershipBL : BusinessObject, IPredictedAgesViewership
    {
        public readonly int MIN_AGE = 15;
        public readonly int MAX_AGE = 80;

        public PredictedAgesViewershipBL(IDALContext dalContext) : base(dalContext)
        {
        }

        public PredictedAgeViewershipCreate Add(PredictedAgeViewershipCreate predictedAgeViewership)
        {
            PredictedAgeViewership addedPredictedAgeViewership = _dalContext.PredictedAgesViewership.Add(PredictedAgeViewershipCreateConverter.ToDALModel(predictedAgeViewership));
            return PredictedAgeViewershipCreateConverter.ToBLLModel(addedPredictedAgeViewership);
        }

        public List<PredictedAgeViewershipRead> GetAll()
        {
            return _dalContext.PredictedAgesViewership
                .GetAll()
                .Select(p => PredictedAgeViewershipReadConverter.ToBLLModel(p))
                .ToList();
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

        public List<Library.MachineLearningModels.PredictedAgeViewership> GetDataByMonth(int year, int month)
        {

            List<MovieSubscription> movieSubscriptions = _dalContext
                .MovieSubscriptions
                .GetAll()
                .Where(m => m.CreatedAt.Year == year &&
                            m.CreatedAt.Month == month)
                .ToList();

            List<SeenMovie> seenMovies = _dalContext
               .SeenMovies
               .GetAll()
               .Where(m => m.CreatedAt.Year == year &&
                           m.CreatedAt.Month == month)
               .ToList();
            List<UserProfile> userProfiles = _dalContext.UserProfiles.GetAll();
            List<UserMovieSearch> userMovieSearches = _dalContext.UserMovieSearches.GetAll()
                                                                                   .Where(u => u.CreatedAt.Year == year &&
                                                                                               u.CreatedAt.Month == month)
                                                                                   .ToList();
            List<Library.MachineLearningModels.PredictedAgeViewership> data = new();
            for (int i = MIN_AGE; i <= MAX_AGE; i++)
            {
                List<UserProfile> ageProfiles = userProfiles
                    .Where(u => CalculateAge(u.DateOfBirth) == i)
                    .ToList();
                if (ageProfiles.Count == 0)
                {
                    continue;
                }
                List<string> userUids = ageProfiles.Select(a => a.UserGUID).ToList();
                int clicksByAge = userMovieSearches.Where(u => userUids.Contains(u.UserGUID))
                                                   .ToList().Count;
                int watchLaterMoviesByAge = seenMovies.Where(s => userUids.Contains(s.UserGUID)).ToList().Count;
                int seenMoviesByAge = seenMovies.Where(s => userUids.Contains(s.UserGUID)).ToList().Count;
                data.Add(new()
                {
                    Age = i,
                    WatchLaterMoviesByAge = watchLaterMoviesByAge,
                    SeenMoviesByAge = seenMoviesByAge,
                    ClicksByAge = clicksByAge
                });
            }
            return data;
        }

        public void ProcessPredictedAgeViwershipAction(int year, int month)
        {
            List<AlgorithmChange> algorithmChanges = _dalContext.AlgorithmChanges.GetAll();
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;
            List<Library.MachineLearningModels.PredictedAgeViewership> predictedAgesViewership = GetDataByMonth(year, month);
            ICSVHandlerService csvHandler = new CSVHandlerService("Files\\Predicting\\test_age_viewership_predicted.csv");
            csvHandler.WriteCSV(predictedAgesViewership);
            List<string> predictedData = ScriptEngine.GetPredictedData("ageViewership", "predict");
            csvHandler.RemoveLastColumn();
            csvHandler.UpdateCsvFile(predictedData, "FuturePredictedMoviesCount");
            List<List<string>> predictedAgesViewershipCsv = csvHandler.ReadCsvFile();
            predictedAgesViewershipCsv = predictedAgesViewershipCsv.Skip(1).ToList();
            csvHandler.AppendRowsToCsv("Files\\Training\\ageViewership.csv", predictedAgesViewershipCsv);
            int i = 0;
            foreach (Library.MachineLearningModels.PredictedAgeViewership predictedAgeViewership in predictedAgesViewership)
            {
                int movieCount = int.Parse(predictedData[i]);
                i++;
                PredictedAgeViewership predictedAgeViewershipModel = new()
                {
                    PredictedAgeViewershipGUID = Guid.NewGuid(),
                    CreatedAt = new DateTime(year, month, 1),
                    Age = predictedAgeViewership.Age,
                    MovieCount = movieCount
                };
                _dalContext.PredictedAgesViewership.Add(predictedAgeViewershipModel);
            }

            ScriptEngine.TrainToPredictModel("ageViewership", "training", currentAlgorithmName);
        }

        public List<AgeViewershipModel> GetByMonth(int year, int month)
        {
            List<PredictedAgeViewership> predictedAgeViewerships = _dalContext.PredictedAgesViewership
                    .GetAll()
                    .Where(p => p.CreatedAt.Year == year &&
                                p.CreatedAt.Month == month)
                    .ToList();
            List<AgeViewershipModel> ageViewershipModels = new();
            foreach (PredictedAgeViewership predictedAgeViewership in predictedAgeViewerships)
            {
                ageViewershipModels.Add(new AgeViewershipModel
                {
                    Age = predictedAgeViewership.Age,
                    Count = predictedAgeViewership.MovieCount
                });
            }
            ageViewershipModels = (from ageViewershipModel in ageViewershipModels
                                   orderby ageViewershipModel.Age
                                   ascending
                                   select ageViewershipModel).ToList();
            return ageViewershipModels;
        }
    }
}