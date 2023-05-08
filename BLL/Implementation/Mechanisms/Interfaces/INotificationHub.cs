using Library.Models.Socket;

namespace BLL.Implementation.Mechanisms.Interfaces
{
    public interface INotificationHub
    {
        Task ReceiveNotification(string message);
    }
}