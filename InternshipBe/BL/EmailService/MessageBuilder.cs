using DAL.Entities;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.EmailService
{
    public class MessageBuilder : IMessageBuilder
    {
        private readonly IEmailBodyGenerator _emailBodyGenerator;
        private readonly EmailConfiguration _emailConfiguration;

        public MessageBuilder(IEmailBodyGenerator generator, EmailConfiguration emailConfiguration)
        {
            _emailBodyGenerator = generator;
            _emailConfiguration = emailConfiguration;
        }

        public async Task<MimeMessage> GenerateMessageForUserAsync(User user, Ticket ticket)
        {
            var messageTemplate = await GenerateMessageTemplateForUserAsync(user, ticket, user.Email, 1);

            var message = CreateEmailMessage(messageTemplate);

            return message;
        }

        public async Task<MimeMessage> GenerateMessageForVendorAsync(User user, Ticket ticket)
        {
            var messageTemplate = await GenerateMessageTemplateForUserAsync(user, ticket, ticket.Discount.Vendor.Email, 2);

            var message = CreateEmailMessage(messageTemplate);

            return message;
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            return emailMessage;
        }

        private async Task<Message> GenerateMessageTemplateForUserAsync(User user, Ticket ticket, string address, int id)
        {
            var contentForVendor = await _emailBodyGenerator.GenerateMessageBodyForUserAsync(user, ticket);

            var subject = $"Discount for {ticket.Discount.Name}";

            var message = new Message()
            {
                To = new MailboxAddress(address),
                Subject = subject,
                Content = contentForVendor
            };
            return message;
        }
    }
}
