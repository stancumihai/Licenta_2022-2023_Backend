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
    internal class PredictedMoviesRuntimeJob : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer? _timer;
        private readonly IAlgorithmChanges _algorithmChangesService;
        private readonly IPredictedMoviesRuntime _predictedMoviesRuntimeService;
        private readonly JobTimeFrame _jobTimeFrame;
        public PredictedMoviesRuntimeJob(ILogger<MovieRecommendationJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration)
        {
            _logger = logger;
            _algorithmChangesService = factory.CreateScope().ServiceProvider.GetRequiredService<IAlgorithmChanges>();
            _predictedMoviesRuntimeService = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedMoviesRuntime>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            _timer = new Timer(ProcessPredictedMoviesRuntimeData, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void ProcessPredictedMoviesRuntimeData(object state)
        {
            List<AlgorithmChangeRead> algorithmChanges = _algorithmChangesService.GetAll();
            string previousAlgorithmName = algorithmChanges[^2].AlgorithmName;
            string currentAlgorithmName = algorithmChanges[^1].AlgorithmName;
            List<Library.MachineLearningModels.PredictedMovieRuntime> predictedMoviesRuntime = await _predictedMoviesRuntimeService.GetLastMonthData();
            ICSVWriterService writer = new CSVWriterService("test_movies_runtimes_predicted.csv");
            writer.WriteCSV(predictedMoviesRuntime);
            var predictedData = ScriptEngine.GetPredictedData("movieRuntime", "predict", previousAlgorithmName);
            //updatedCsv = UpdateCsv(predictedMovieCounts);
            //AppendToDummyCsv(updatedCsv);
            ScriptEngine.TrainToPredictModel("movieRuntime", "train", currentAlgorithmName);
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