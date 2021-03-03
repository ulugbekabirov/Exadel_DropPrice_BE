using AutoMapper;
using BL.DTO;
using BL.Mapping;
using BL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Services
{
    public class TicketServiceTest
    {
        private static IMapper _mapper;

        public TicketServiceTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task GetOrCreateTicketAsync_UserTicketIsNull_ReturnsCreatedTicket()
        {
            //Arrange
            var user = new User
            {
                Id = 1,
                FirstName = "Альберт",
                LastName = "Эйнштейн",
                Patronymic = "Германович",
                Phone = "+375447777777",
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

            var expectedOutputTicketDTO = new TicketDTO()
            {
                DiscountId = 1,
                VendorId = 1,
                FirstName = "Альберт",
                LastName = "Эйнштейн",
                Patronymic = "Германович",
                DiscountName = "Пицца темпо",
                VendorEmail = "vendorexadel@gmail.com",
                VendorPhone = "+998 71 2031212",
                PromoCode = null,
                DiscountAmount = 12,
                OrderDate = DateTime.Now,
                IsExpired = false,
                DiscountActivity = true,
                IsSavedDiscount = true
            };

            var mockTicketRepository = new Mock<ITicketRepository>();
            mockTicketRepository.Setup(rep => rep.GetTicketAsync(discount.Id, user.Id)).Returns(GetTestNullUserTicket());
            mockTicketRepository.Setup(rep => rep.CreateTicketAsync(discount.Id, user)).Returns(GetTestTicket(user, discount));

            var mockDiscountRepository = new Mock<IDiscountRepository>();
            mockDiscountRepository.Setup(rep => rep.IsSavedDiscountAsync(discount.Id, user.Id)).Returns(IsSavedDiscountTest(discount, user));

            var mockConfigRepository = new Mock<IConfigRepository>();
            mockConfigRepository.Setup(rep => rep.IsSendingEmailsEnabled(1)).Returns(GetTestEmail());

            var ticketService = new TicketService(mockTicketRepository.Object, mockDiscountRepository.Object, _mapper, null, null, mockConfigRepository.Object);

            //Act
            var newticketDTO = await ticketService.GetOrCreateTicketAsync(discount.Id, user);

            //Assest
            Assert.Equal(expectedOutputTicketDTO, newticketDTO);
        }

        private async Task<bool> GetTestEmail()
        {
            return false;
        }

        private async Task<Ticket> GetTestNullUserTicket()
        {
            return null;
        }

        private async Task<Ticket> GetTestTicket(User user, Discount discount)
        {
            return new Ticket()
            {
                UserId = user.Id,
                User = user,
                DiscountId = discount.Id,
                Discount = discount,
                OrderDate = DateTime.Now,
            };
        }

        private async Task<bool> IsSavedDiscountTest(Discount discount, User user)
        {
            var savedDiscounts = new List<SavedDiscount>()
            {
                new SavedDiscount() { Id = 1, DiscountId = 1, UserId = 1},
                new SavedDiscount() { Id = 2, DiscountId = 1, UserId = 2 },
                new SavedDiscount() { Id = 3, DiscountId = 1, UserId = 3 },
                new SavedDiscount() { Id = 4, DiscountId = 2, UserId = 1 },
                new SavedDiscount() { Id = 5, DiscountId = 3, UserId = 1 },
            };

            return savedDiscounts.Any(s => s.DiscountId == discount.Id && s.UserId == user.Id);
        }
    }
}