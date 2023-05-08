using BLL.Implementation.Mechanisms.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BLL.Implementation.Mechanisms
{
    public class NotificationHub : Hub<INotificationHub>
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveNotification(message);
        }
    }
}