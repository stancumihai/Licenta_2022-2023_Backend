using BLL.Interfaces;
using BLL.Interfaces.MachineLearning;
using Library.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BLL.Implementation.Mechanisms.Jobs
{
    internal class PredictedData : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer? _timer;
        private readonly IPredictedGenres _predictedGenresService;
        private readonly IPredictedMoviesCount _predictedMoviesCount;
        private readonly IPredictedMoviesRuntime _predictedMoviesRuntime;
        private readonly IPredictedAgesViewership _predictedAgesViewership;

        private readonly JobTimeFrame _jobTimeFrame;
        public PredictedData(ILogger<MovieRecommendationJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration)
        {
            _logger = logger;
            _predictedGenresService = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedGenres>();
            _predictedMoviesCount = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedMoviesCount>();
            _predictedMoviesRuntime = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedMoviesRuntime>();
            _predictedAgesViewership = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedAgesViewership>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            //_timer = new Timer(ProcessPredictedData, null, TimeSpan.Zero,
            //    TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void ProcessPredictedData(object state)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month + 2;
            //await _predictedGenresService.ProcessPredictedGenreJobAction(year, month);
            //await _predictedMoviesCount.ProcessPredictedMovieCountJobAction(year, month);
            //await _predictedMoviesRuntime.ProcessPredictedMovieRuntimeJobAction(year, month);
            _predictedAgesViewership.ProcessPredictedAgeViwershipAction(year, month);
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