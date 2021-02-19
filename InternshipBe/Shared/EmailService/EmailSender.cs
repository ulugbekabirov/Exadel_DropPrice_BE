using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendEmailAsync(Message message)
        {
            var emailMessageForUser = CreateEmailMessageForUser(message);
            var emailMessageForVendor = CreateEmailMessageForVendor(message);

            await SendAsync(emailMessageForUser);
            await SendAsync(emailMessageForVendor);
        }

        private MimeMessage CreateEmailMessageForUser(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emailMessage.To.Add(message.To[0]);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content[0] };

            return emailMessage;
        }

        private MimeMessage CreateEmailMessageForVendor(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emailMessage.To.Add(message.To[1]);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content[1] };

            return emailMessage;
        }

        private async Task SendAsync(MimeMessage message)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
            await client.SendAsync(message);
        }
    }
}
