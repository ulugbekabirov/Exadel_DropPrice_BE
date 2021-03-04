using AutoMapper;
using BL.EmailService;
using BL.Interfaces;
using BL.Mapping;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using MimeKit;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.EmailService
{
    public class MessageBuilderTests
    {
        private Mock<IConfigRepository> _configRepository;
        private IMapper _mapper;
        private Mock<IEmailBodyGenerator> _emailBodyGenerator;

        public MessageBuilderTests()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile())).CreateMapper();
            _configRepository = new Mock<IConfigRepository>();
            _configRepository.Setup(rep => rep.GetMessageTemplateFromCurrentCultureAsync()).Returns(GetMessageTemplateFromCurrentCultureAsyncTest());
            _emailBodyGenerator = new Mock<IEmailBodyGenerator>();
            _emailBodyGenerator.Setup(rep => rep.GenerateMessageBody(null, null, null)).Returns(GenerateMessageBodyTest());
        }

        private async Task<MessageTemplates> GetMessageTemplateFromCurrentCultureAsyncTest()
        {
            return new MessageTemplates
            {
                UserTemplate = "content",
            };
        }

        private string GenerateMessageBodyTest()
        {
            return "content";
        }

        [Fact]
        public async Task GenerateMessageForUserAsync_WhenCalled_StringModifiedWithRegulars()
        {
            //Arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "Альберт",
                LastName = "Эйнштейн",
                Patronymic = "Германович",
                Phone = "+375447777777",
                Email = "userexadel@gmail.com"
            };

            var vendor = new Vendor()
            {
                Id = 1,
                Name = "KFC",
                Email = "vendorexadel@gmail.com",
                Phone = "+998 71 2031212"
            };

            var discount = new Discount()
            {
                Id = 1,
                Name = "kfc",
                Vendor = vendor,
                DiscountAmount = 12,
                PromoCode = null,
                ActivityStatus = true,
            };

            var ticket =  new Ticket()
            {
                UserId = user.Id,
                User = user,
                DiscountId = discount.Id,
                Discount = discount,
                OrderDate = DateTime.Now,
            };

            var emailConfiguration = new EmailConfigurationModel()
            {
                From = "dropprice@gmail.com"
            };

            var messageBuilder = new MessageBuilder(_emailBodyGenerator.Object, emailConfiguration, _configRepository.Object, _mapper);

            var expectedOutput = new MimeMessage();
            expectedOutput.From.Add(new MailboxAddress("dropprice@gmail.com"));
            expectedOutput.To.Add(new MailboxAddress("userexadel@gmail.com"));
            expectedOutput.Subject = "KFC - kfc";
            expectedOutput.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "content" };

            //Act
            var output = await messageBuilder.GenerateMessageForUserAsync(user, ticket);

            //Assert
            //Now it compares by object adress
            //To be fixed later
            Assert.Equal(output, expectedOutput);
        }
    }
}
