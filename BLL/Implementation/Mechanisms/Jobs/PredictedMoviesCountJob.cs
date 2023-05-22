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
    internal class PredictedMoviesCountJob : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer? _timer;
        private readonly IAlgorithmChanges _algorithmChangesService;
        private readonly IPredictedMoviesCount _predictedMoviesCountService;
        private readonly JobTimeFrame _jobTimeFrame;
        public PredictedMoviesCountJob(ILogger<MovieRecommendationJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration)
        {
            _logger = logger;
            _algorithmChangesService = factory.CreateScope().ServiceProvider.GetRequiredService<IAlgorithmChanges>();
            _predictedMoviesCountService = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedMoviesCount>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            _timer = new Timer(ProcessPredictedMoviesCountData, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void ProcessPredictedMoviesCountData(object state)
        {
            List<AlgorithmChangeRead> algorithmChanges = _algorithmChangesService.GetAll();
            string previousAlgorithmName = algorithmChanges[^2].AlgorithmName;
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;

            List<Library.MachineLearningModels.PredictedMovieCount> predictedMoviesCount = await _predictedMoviesCountService.GetLastMonthData();
            ICSVWriterService writer = new CSVWriterService("test_movies_count_predicted.csv");
            writer.WriteCSV(predictedMoviesCount);
            var predictedData = ScriptEngine.GetPredictedData("movieCount", "predict", previousAlgorithmName);
            //updatedCsv = UpdateCsv(predictedData);
            //AppendToDummyCsv(updatedCsv);
            ScriptEngine.TrainToPredictModel("movieCount", "train", currentAlgorithmName);
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