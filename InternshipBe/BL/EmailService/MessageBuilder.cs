using DAL.Entities;
using MimeKit;
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
            var messageTemplate = await GenerateMessageTemplateForUserAsync(user, ticket, user.Email);

            var message = CreateEmailMessage(messageTemplate);

            return message;
        }

        public async Task<MimeMessage> GenerateMessageForVendorAsync(User user, Ticket ticket)
        {
            var messageTemplate = await GenerateMessageTemplateForVendorAsync(user, ticket, ticket.Discount.Vendor.Email);

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

        private async Task<Message> GenerateMessageTemplateForUserAsync(User user, Ticket ticket, string address)
        {
            var contentForUser = await _emailBodyGenerator.GenerateMessageBodyForUserAsync(user, ticket);

            var subject = $"Discount for {ticket.Discount.Name}";

            var message = new Message()
            {
                To = new MailboxAddress(address),
                Subject = subject,
                Content = contentForUser
            };
            return message;
        }

        private async Task<Message> GenerateMessageTemplateForVendorAsync(User user, Ticket ticket, string address)
        {
            var contentForVendor = await _emailBodyGenerator.GenerateMessageBodyForVendorAsync(user, ticket);

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
