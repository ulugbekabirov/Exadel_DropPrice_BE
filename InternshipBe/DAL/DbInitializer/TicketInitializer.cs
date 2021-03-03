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
            AddMultipleTickets("user0@test.com", 6, 34);

            /*            //admin
                        AddTicket(2, 3, DateTime.Now.AddDays(-1));
                        AddTicket(1, 5, DateTime.Now.AddDays(-1));
                        AddTicket(1, 5, DateTime.Now);
                        AddTicket(1, 6, DateTime.Now);
                        AddTicket(1, 7, DateTime.Now);
                        AddTicket(1, 12, DateTime.Now.AddDays(-3));

                        //moderator
                        AddTicket(2, 3, DateTime.Now.AddDays(-1));
                        AddTicket(2, 5, DateTime.Now.AddDays(-2));
                        AddTicket(2, 17, DateTime.Now.AddDays(-1));
                        AddTicket(2, 7, DateTime.Now);
                        AddTicket(2, 11, DateTime.Now.AddDays(-3));

                        //user
                        AddTicket(3, 5, DateTime.Now.AddDays(-1));
                        AddTicket(3, 5, DateTime.Now);
                        AddTicket(3, 6, DateTime.Now);
                        AddTicket(3, 21, DateTime.Now.AddDays(-1));
                        AddTicket(3, 25, DateTime.Now.AddDays(-2));

                        //userGomel
                        AddTicket(4, 13, DateTime.Now.AddDays(-3));
                        AddTicket(4, 8, DateTime.Now.AddDays(-1));
                        AddTicket(4, 11, DateTime.Now.AddDays(-1));

                        //userTashkent
                        AddTicket(6, 13, DateTime.Now.AddDays(-2));
                        AddTicket(6, 1, DateTime.Now.AddDays(-1));
                        AddTicket(6, 6, DateTime.Now.AddDays(-1));
                        */


            /*            foreach (User user in _context.Users)
                        {
                            var existingTickets = new List<int>();

                            int i = 2;
                            while (i > 0)
                            {
                                var discountId = rnd.Next(1, 98);

                                if (!existingTickets.Contains(discountId))
                                {
                                    var userId = user.Id;
                                    existingTickets.Add(discountId);
                                    AddTicket(userId, discountId, DateTime.Now.AddDays(-1));
                                }

                                i--;
                            }
                        }
            */
          }
    }
}
