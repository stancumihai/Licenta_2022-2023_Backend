using BLL.Interfaces.MachineLearning;
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
        private readonly IPredictedMoviesCount _predictedMoviesCount;

        private readonly JobTimeFrame _jobTimeFrame;
        public PredictedMoviesCountJob(ILogger<PredictedMoviesCountJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration)
        {
            _logger = logger;
            _predictedMoviesCount = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedMoviesCount>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            //_timer = new Timer(ProcessPredictedMovieCountJob, null, TimeSpan.Zero,
            //    TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void ProcessPredictedMovieCountJob(object state)
        {
            Console.WriteLine("Predicted Movies Count Job");
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            await _predictedMoviesCount.ProcessPredictedMovieCountJobAction(year, month);
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