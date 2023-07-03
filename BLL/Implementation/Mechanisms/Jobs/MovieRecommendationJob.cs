using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces;
using BLL.Interfaces.MachineLearning;
using BLL.Interfaces.Mechanisms;
using Library.Models.Recommendation;
using Library.Models.Users;
using Library.Settings;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BLL.Implementation.Mechanisms.Jobs
{
    internal class MovieRecommendationJob : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer? _timer;
        private readonly IEmailSender _emailSender;
        private readonly IRecommendations _recommendationService;
        private readonly IUsers _usersService;
        private readonly JobTimeFrame _jobTimeFrame;
        private readonly IPredictedGenres _predictedGenresService;

        private readonly IHubContext<NotificationHub, INotificationHub> _notificationHubContext;
        public MovieRecommendationJob(ILogger<MovieRecommendationJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration,
            IHubContext<NotificationHub, INotificationHub> notificationHubContext)
        {
            _logger = logger;
            _emailSender = factory.CreateScope().ServiceProvider.GetRequiredService<IEmailSender>();
            _usersService = factory.CreateScope().ServiceProvider.GetRequiredService<IUsers>();
            _predictedGenresService = factory.CreateScope().ServiceProvider.GetRequiredService<IPredictedGenres>();
            _recommendationService = factory.CreateScope().ServiceProvider.GetRequiredService<IRecommendations>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
            _notificationHubContext = notificationHubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            //_timer = new Timer(ProcessMovieRecommendationJob, null, TimeSpan.Zero,
            //    TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void ProcessMovieRecommendationJob(object state)
        {
            Console.WriteLine("Predicted Genres and Recommendations job");
            _logger.LogInformation("service is running.");
            int year = DateTime.Now.Year;
            int month = 7;
            //await _predictedGenresService.ProcessPredictedGenreJobAction(year, month);
            await _recommendationService.ProcessPredictedMoviesJobAction(year, month);
            //foreach (UserRead user in _usersService.GetAll())
            //{
            //    string body = "<p>Here are the this month recommendations:</p>";
            //    string email = user.Email;
            //    try
            //    {
            //        List<RecommendationRead> recommendations = _recommendationService.GetAllByUserAndMonth(user.Uid.ToString(), DateTime.Now.Year, DateTime.Now.Month);
            //        body += "<ul>";
            //        foreach (RecommendationRead recommendation in recommendations)
            //        {
            //            body += "<li>" + recommendation.Movie.Title + "</li>";
            //        }
            //        body += "</ul>";
            //        var message = new Message(new string[] { email },
            //        "Movie Recommendations",
            //        body,
            //        null);
            //        _emailSender.SendEmail(message);
            //        _logger.LogInformation($"Email sent to {email}");
            //        await _notificationHubContext.Clients.All.ReceiveNotification("Yes");
            //    }
            //    catch (Exception e)
            //    {
            //        _logger.LogError(e, e.Message);
            //    }
            //}
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