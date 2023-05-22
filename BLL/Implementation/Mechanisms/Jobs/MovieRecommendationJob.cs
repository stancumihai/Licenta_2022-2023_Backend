using BLL.Implementation.Mechanisms.Interfaces;
using BLL.Interfaces;
using BLL.Interfaces.Mechanisms;
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
        private readonly IUsers _usersService;
        private List<UserRead> _users;
        private readonly JobTimeFrame _jobTimeFrame;
        private readonly IHubContext<NotificationHub, INotificationHub> _notificationHubContext;
        public MovieRecommendationJob(ILogger<MovieRecommendationJob> logger,
            IServiceScopeFactory factory,
            IConfiguration configuration,
           IHubContext<NotificationHub, INotificationHub> notificationHubContext)
        {
            _logger = logger;
            _emailSender = factory.CreateScope().ServiceProvider.GetRequiredService<IEmailSender>();
            _usersService = factory.CreateScope().ServiceProvider.GetRequiredService<IUsers>();
            _jobTimeFrame = configuration
                .GetSection("JobTimeFrame")
                .Get<JobTimeFrame>();
            _users = _usersService.GetAll();
            _notificationHubContext = notificationHubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            _timer = new Timer(SendEmail, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(_jobTimeFrame.Time));
            return Task.CompletedTask;
        }

        private async void SendEmail(object state)
        {
            _logger.LogInformation("service is running.");
            string body = "<p>Here are the this month recommendations</p>";
            foreach (UserRead user in _users)
            {
                string email = user.Email;
                var message = new Message(new string[] { email },
                    "Change Password",
                    body,
                    null);
                try
                {
                    //_emailSender.SendEmail(message);
                    _logger.LogInformation($"Email sent to {email}");
                    await _notificationHubContext.Clients.All.ReceiveNotification("Yes");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
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