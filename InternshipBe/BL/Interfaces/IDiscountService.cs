using BL.DTO;
using BL.Models;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IDiscountService 
    {
        Task<IEnumerable<DiscountDTO>> GetDiscountsAsync(SortModel sortModel, User user);

        Task<IEnumerable<DiscountDTO>> SearchAsync(SearchModel searchModel, User user);

        Task<DiscountDTO> GetDiscountByIdAsync(int discountId, User user);

        Task<SavedDTO> SaveOrUnsaveDisocuntAsync(int discountId, User user);
    }
}
