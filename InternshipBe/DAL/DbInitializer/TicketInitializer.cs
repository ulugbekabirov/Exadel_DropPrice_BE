using DAL.DataContext;
using DAL.Entities;
using System;
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

        public void InitializerTickets()
        {
            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 1);
            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 2);
            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 3);

            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 4);
            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 5);
            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 6);

            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 7);
            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 8);
            AddTicket(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 9);
        }

        public void AddTicket(int userId, int discountId)
        {
            var ticket = new Ticket()
            {
                UserId = userId,
                DiscountId = discountId,
                OrderDate = DateTime.Now,
            };

            _context.Tickets.Add(ticket);
            _context.Users.Find(userId).Tickets.Add(ticket);
            _context.Discounts.Find(discountId).Tickets.Add(ticket);

            _context.SaveChanges();
        }
    }
}
