using DAL.Entities;
using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;
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

        public Message GenerateMessageTemplate(User user, Ticket ticket)
        {
            var content = $"This is test message for {user.Email}, {ticket.Discount.Vendor.Name} have given you the ticket as a discount certificate for {ticket.Discount.Name} at {ticket.OrderDate}";

            var subject = $"Discount for {ticket.Discount.Name}";

            var message = new Message()
            {
                To = new List<MailboxAddress>() {new MailboxAddress(user.Email),new MailboxAddress(ticket.Discount.Vendor.Email)},
                Subject = subject,
                Content = content,

            };
            return message;
        }

    public async Task SendEmailAsync(Message message)
    {
        var emailMessage = CreateEmailMessage(message);

        await SendAsync(emailMessage);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

        return emailMessage;
    }

    private async Task SendAsync(MimeMessage message)
    {
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
            await client.SendAsync(message);
        }
    }
}
}
