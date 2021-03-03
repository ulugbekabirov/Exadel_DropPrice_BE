using AutoMapper;
using BL.Mapping;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
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

        public MessageBuilderTests()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile())).CreateMapper();
            _configRepository = new Mock<IConfigRepository>();
            _configRepository.Setup(rep => rep.GetMessageTemplateFromCurrentCultureAsync()).Returns(GetMessageTemplateFromCurrentCultureAsyncTest());
        }

        private async Task<MessageTemplates> GetMessageTemplateFromCurrentCultureAsyncTest()
        {
            return new MessageTemplates
            {
                UserTemplate = "",
            };
        }

        private async Task<EmailTemplateModel> GetTemplateAsyncTest()
        {

        }

        [Fact]
        public void GenerateMessageForUserAsync_WhenCalled_StringModifiedWithRegulars()
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
                Email = "vendorexadel@gmail.com",
                Phone = "+998 71 2031212"
            };

            var discount = new Discount()
            {
                Id = 1,
                Name = "Пицца темпо",
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

            //Act
             




        }
    }
}
