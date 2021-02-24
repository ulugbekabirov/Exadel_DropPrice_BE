using BL.Interfaces;
using BL.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace BL.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfigurationModel _emailConfiguration;

        public EmailSender(EmailConfigurationModel emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendAsync(MimeMessage message)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
            await client.SendAsync(message);
        }
    }
}
