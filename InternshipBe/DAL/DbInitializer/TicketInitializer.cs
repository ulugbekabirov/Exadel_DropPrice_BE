using DAL.DataContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DbInitializer
{
    public class TicketInitializer
    {
        private readonly ApplicationDbContext _context;

        public TicketInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        private void AddTicket(string email, int discountId, DateTime orderDate)
        {
            var userId = _context.Users.SingleOrDefault(u => u.Email == email).Id;
            var user = _context.Users.Find(userId);
            var discount = _context.Discounts.Find(discountId);

            var ticket = new Ticket()
            {
                DiscountId = discountId,
                User = user,
                Discount = discount,
                UserId = userId,
                OrderDate = orderDate
            };

            _context.Tickets.Add(ticket);

            _context.SaveChanges();
        }

        private void AddMultipleTickets(string email, int discountIdStart, int discountIdStop)
        {
            var randomDay = new Random();
            for (; discountIdStart < discountIdStop; discountIdStart++)
            {
                AddTicket(email, discountIdStart, DateTime.Now.AddDays(randomDay.Next(-5,0)));
            }
        }

        public void InitializeTickets()
        {
            AddMultipleTickets("userGomel@test.com", 8, 43);
            AddMultipleTickets("userWarszawa@test.com", 1, 64);
            AddMultipleTickets("userTashkent@test.com", 32, 85);
            AddMultipleTickets("userUsa@test.com", 61, 98);
            AddMultipleTickets("userTashkent@test.com", 32, 85);
            AddMultipleTickets("user0@test.com", 86, 96);
            AddMultipleTickets("user3@test.com", 86, 98);
            AddMultipleTickets("user1@test.com", 1, 32);
            AddMultipleTickets("user2@test.com", 26, 53);
            AddMultipleTickets("user4@test.com", 4, 60);
            AddMultipleTickets("user5@test.com", 1, 85);
            AddMultipleTickets("user7@test.com", 64, 85);
            AddMultipleTickets("user8@test.com", 32, 70);
            AddMultipleTickets("user9@test.com", 1, 76);
            AddMultipleTickets("user0@test.com", 6, 34);
        }
    }
}
