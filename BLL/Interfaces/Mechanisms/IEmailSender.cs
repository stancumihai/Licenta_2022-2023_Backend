using Library.Settings;

namespace BLL.Interfaces.Mechanisms
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}