using BL.DTO;
using BL.Models;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserInfoAsync(User user);

        Task<IEnumerable<DiscountDTO>> GetUserSavedDiscountsAsync(LocationModel locationModel, User user);

        Task<IEnumerable<TicketDTO>> GetUserTicketsAsync(User user, SpecifiedAmountModel specifiedAmountModel);
    }
}
