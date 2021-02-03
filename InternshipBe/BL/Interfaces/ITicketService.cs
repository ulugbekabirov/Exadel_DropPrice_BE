using BL.DTO;
using DAL.Entities;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITicketService 
    {
        Task<TicketDTO> GetOrCreateTicketAsync(int discountId, User user);
    }
}
