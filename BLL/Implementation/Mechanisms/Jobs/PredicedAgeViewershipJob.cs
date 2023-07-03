using BLL.Interfaces.MachineLearning;
using Library.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BLL.Implementation.Mechanisms.Jobs
{
    internal class PredicedAgeViewershipJob : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer? _timer;
        private readonly IPredictedAgesViewership _predictedAgesViewership;

        private readonly JobTimeFrame _jobTimeFrame;
        public PredicedAgeViewershipJob(ILogger<PredicedAgeViewershipJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration)
        {
            _logger = logger;
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
            Console.WriteLine("Predicted Ages Viewership Job");
            int year = DateTime.Now.Year;
            int month = 7;
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