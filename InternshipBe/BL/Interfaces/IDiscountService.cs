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

        Task<DiscountDTO> GetDiscountByIdAsync(int id, LocationModel locationModel, User user);

        Task<SavedDTO> SaveOrUnsaveDisocuntAsync(int id, User user);

        Task<ArchivedDiscountDTO> ArchiveOrUnarchiveDiscount(int id);
    }
}
