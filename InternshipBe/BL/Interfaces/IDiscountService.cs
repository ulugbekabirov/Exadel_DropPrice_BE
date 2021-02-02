using BL.DTO;
using BL.Models;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IDiscountService 
    {
        Task<IEnumerable<DiscountDTO>> GetClosestAsync(SortModel model, User user);
    }
}
