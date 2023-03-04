using Microsoft.AspNetCore.Http;
using MimeKit;

namespace Library.Settings
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("email", x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }

        public override string? ToString()
        {
            return "To: " + To[0] +
                " Subject: " + Subject +
                " Content: " + Content;
        }
    }
}
