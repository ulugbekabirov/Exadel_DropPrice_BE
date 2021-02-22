using MimeKit;
using System;
using System.Collections.Generic;

namespace Shared.EmailService
{
    public class Message
    {
        public MailboxAddress To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
