using DAL.Entities;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public class MessageBuilder : IMessageBuilder
    {
        private readonly IEmailBodyGenerator _emailBodyGenerator;

        public MessageBuilder(IEmailBodyGenerator generator)
        {
            _emailBodyGenerator = generator;
        }

        public async Task<Message> GenerateMessageTemplateForUserAsync(User user, Ticket ticket)
        {
            var contentForUser = await _emailBodyGenerator.GenerateMessageBodyAsync(user, ticket, 1);

            var subject = $"Discount for {ticket.Discount.Name}";

            var message = new Message()
            {
                To = new MailboxAddress(user.Email),
                Subject = subject,
                Content = contentForUser
            };
            return message;
        }

        public async Task<Message> GenerateMessageTemplateForVendorAsync(User user, Ticket ticket)
        {
            var contentForVendor = await _emailBodyGenerator.GenerateMessageBodyAsync(user, ticket, 2);

            var subject = $"Discount for {ticket.Discount.Name}";

            var message = new Message()
            {
                To = new MailboxAddress(ticket.Discount.Vendor.Email),
                Subject = subject,
                Content = contentForVendor
            };
            return message;
        }

    }
}
