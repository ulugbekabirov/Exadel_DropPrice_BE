using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<Ticket> GetTicketAsync(int discountId, int userId);

        Task<IEnumerable<Ticket>> GetTicketsAsync(int userId, int skip, int take);

        Task<Ticket> CreateAndReturnTicketAsync(int discountId, User user);
    }
}
