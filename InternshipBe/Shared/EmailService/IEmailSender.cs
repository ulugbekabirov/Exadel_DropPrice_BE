using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Message GenerateMessageTemplate(User user, Ticket ticket);
    }
}
