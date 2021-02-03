using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Ticket> GetOrCreateTicketForUserAsync(int discountId, User user)
        {
            var ticket = await _context.Tickets.SingleOrDefaultAsync(d => d.DiscountId == discountId && d.UserId == user.Id && d.OrderDate.Date == DateTime.Today.Date);
            
            if (ticket is null)
            {
                var discount = await _context.Discounts.FindAsync(discountId);

                var newTicket = new Ticket()
                {
                    DiscountId = discountId,
                    UserId = user.Id,
                    OrderDate = DateTime.Now,
                    User = user,
                    Discount = discount,
                };

                user.Tickets.Add(newTicket);
                discount.Tickets.Add(newTicket);
                
                await CreateAsync(newTicket);

                return newTicket;
            }

            return ticket;
        }
    }
}
