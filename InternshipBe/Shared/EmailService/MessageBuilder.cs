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

        public async Task<Message> GenerateMessageTemplateAsync(User user, Ticket ticket)
        {
            var contentForUser = await _emailBodyGenerator.GenerateUserBody(user, ticket);
            var contentForVendor = await _emailBodyGenerator.GenerateVendorBody(user, ticket);
            var subject = $"Discount for {ticket.Discount.Name}";

            var message = new Message()
            {
                To = new List<MailboxAddress>() { new MailboxAddress(user.Email), new MailboxAddress(ticket.Discount.Vendor.Email) },
                Subject = subject,
                Content = new List<string> { contentForUser, contentForVendor }

            };
            return message;
        }
    }
}
