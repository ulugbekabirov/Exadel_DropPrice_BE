using DAL.Entities;
using MimeKit;
using System.Collections.Generic;

namespace Shared.EmailService
{
    public class MessageBuilder: IMessageBuilder
    {
        public Message GenerateMessageTemplate(User user, Ticket ticket)
        {
            var content = $"This is test message for {user.Email}, {ticket.Discount.Vendor.Name} have given you the ticket as a discount certificate for {ticket.Discount.Name} at {ticket.OrderDate}";

            var subject = $"Discount for {ticket.Discount.Name}";

            var message = new Message()
            {
                To = new List<MailboxAddress>() { new MailboxAddress(user.Email), new MailboxAddress(ticket.Discount.Vendor.Email) },
                Subject = subject,
                Content = content,

            };
            return message;
        }
    }
}
