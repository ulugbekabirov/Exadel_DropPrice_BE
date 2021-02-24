using MimeKit;

namespace BL.Models
{
    public class MessageModel
    {
        public MailboxAddress To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
