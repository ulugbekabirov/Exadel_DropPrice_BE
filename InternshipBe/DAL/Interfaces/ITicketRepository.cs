using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<Ticket> GetOrCreateTicketForUserAsync(int discountId, User user);
    }
}
