using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Shared.EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
