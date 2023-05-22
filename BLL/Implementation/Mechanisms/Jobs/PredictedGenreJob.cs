using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces;
using BLL.Interfaces.MachineLearning;
using Library.Models.AlgorithmChange;
using Library.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BLL.Implementation.Mechanisms.Jobs
{
    internal class PredictedGenreJob : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer? _timer;
        private readonly IAlgorithmChanges _algorithmChangesService;
        private readonly IPredictedGenres _predictedGenresService;
        private readonly JobTimeFrame _jobTimeFrame;
        public PredictedGenreJob(ILogger<MovieRecommendationJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration)
        {
            _logger = logger;
            _algorithmChangesService = factory.CreateScope().ServiceProvider.GetRequiredService<IAlgorithmChanges>();
            _predictedGenresService = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedGenres>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            _timer = new Timer(ProcessPredictedGenresData, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void ProcessPredictedGenresData(object state)
        {
            List<AlgorithmChangeRead> algorithmChanges = _algorithmChangesService.GetAll();
            string previousAlgorithmName = algorithmChanges[^2].AlgorithmName;
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;
            List<Library.MachineLearningModels.PredictedGenre> predictedGenres = await _predictedGenresService.GetLastMonthData();
            ICSVWriterService writer = new CSVWriterService("test_genres_predicted.csv");
            writer.WriteCSV(predictedGenres);
            var predictedData = ScriptEngine.GetPredictedData("genres", "predict", previousAlgorithmName);
            //updatedCsv = UpdateCsv(predictedMovieCounts);
            //AppendToDummyCsv(updatedCsv);
            ScriptEngine.TrainToPredictModel("genres", "train", currentAlgorithmName);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}