using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Ticket> GetTicketAsync(int discountId, int userId)
        {
            return await _context.Tickets.SingleOrDefaultAsync(d => d.DiscountId == discountId && d.UserId == userId && d.OrderDate.Date == DateTime.Today.Date);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int userId, int skip, int take)
        {
            return await GetSpecifiedAmount(skip, take).Where((d => d.UserId == userId)).ToListAsync();
        }

        public async Task<Ticket> CreateTicketAsync(int discountId, User user)
        {
            var discount = await _context.Discounts.FindAsync(discountId);

            var newTicket = new Ticket()
            {
                DiscountId = discount.Id,
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
    }
}
