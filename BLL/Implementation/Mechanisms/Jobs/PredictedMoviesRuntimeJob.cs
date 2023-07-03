using BLL.Interfaces.MachineLearning;
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
        private readonly IPredictedMoviesRuntime _predictedMoviesRuntime;

        private readonly JobTimeFrame _jobTimeFrame;
        public PredictedMoviesRuntimeJob(ILogger<PredictedMoviesRuntimeJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration)
        {
            _logger = logger;
            _predictedMoviesRuntime = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedMoviesRuntime>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            //_timer = new Timer(ProcessPredictedMovieRuntimesJob, null, TimeSpan.Zero,
            //    TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void ProcessPredictedMovieRuntimesJob(object state)
        {
            Console.WriteLine("Predicted Movies Runtime Job");
            int year = DateTime.Now.Year;
            int month = 5;
            await _predictedMoviesRuntime.ProcessPredictedMovieRuntimeJobAction(year, month);
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