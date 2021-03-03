using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using MimeKit;
using System.Threading.Tasks;

namespace BL.EmailService
{
    public class MessageBuilder : IMessageBuilder
    {
        private readonly IEmailBodyGenerator _emailBodyGenerator;
        private readonly EmailConfigurationModel _emailConfiguration;
        private readonly IConfigRepository _сonfigRepository;
        private readonly IMapper _mapper;

        public MessageBuilder(IEmailBodyGenerator generator, EmailConfigurationModel emailConfiguration, IConfigRepository сonfigRepository, IMapper mapper)
        {
            _emailBodyGenerator = generator;
            _emailConfiguration = emailConfiguration;
            _сonfigRepository = сonfigRepository;
            _mapper = mapper;
        }

        public async Task<MimeMessage> GenerateMessageForUserAsync(User user, Ticket ticket)
        {
            var template = await GetTemplateAsync();

            return CreateEmailMessage(user, ticket, user.Email, template.UserTemplate);
        }

        public async Task<MimeMessage> GenerateMessageForVendorAsync(User user, Ticket ticket)
        {
            var template = await GetTemplateAsync();

            return CreateEmailMessage(user, ticket, ticket.Discount.Vendor.Email, template.VendorTemplate);
        }

        private async Task<EmailTemplateModel> GetTemplateAsync()
        {
            var emailTemplate = await _сonfigRepository.GetMessageTemplateFromCurrentCultureAsync();
            var emailTemplateModel = _mapper.Map<EmailTemplateModel>(emailTemplate);

            return emailTemplateModel;
        }

        private MimeMessage CreateEmailMessage(User user, Ticket ticket, string address, string messageTemplate)
        {
            var message = GenerateMessageTemplate(user, ticket, address, messageTemplate);

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            return emailMessage;
        }

        private MessageModel GenerateMessageTemplate(User user, Ticket ticket, string address, string messgaeTemplate)
        {
            var contentForUser = _emailBodyGenerator.GenerateMessageBody(user, ticket, messgaeTemplate);

            var subject = $"{ticket.Discount.Vendor.Name} - { ticket.Discount.Name }";

            var message = new MessageModel()
            {
                To = new MailboxAddress(address),
                Subject = subject,
                Content = contentForUser
            };
            return message;
        }
    }
}
