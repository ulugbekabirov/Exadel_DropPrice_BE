using BL.DTO;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IDiscountService 
    {
        Task<IEnumerable<DiscountDTO>> GetClosestAsync(int skip, int take, double latitude, double longitude, User user);
    }
}
