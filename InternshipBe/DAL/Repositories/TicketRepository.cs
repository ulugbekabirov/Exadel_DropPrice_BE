using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Ticket> GetOrCreateTicketForUser(int discountId, User user)
        {
            var ticket = await _context.Tickets.SingleOrDefaultAsync(d => d.DiscountId == discountId && d.UserId == user.Id && d.OrderDate == DateTime.Today);

            if (ticket is null)
            {
                var newTicket = new Ticket()
                {
                    DiscountId = discountId,
                    UserId = user.Id,
                    OrderDate = DateTime.Now,
                    User = user,
                    Discount = await _context.Discounts.SingleAsync(d => d.Id == discountId),
                };

                await CreateAsync(newTicket);
                return newTicket;
            }

            return ticket;
        }
    }
}
