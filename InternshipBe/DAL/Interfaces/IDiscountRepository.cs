using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        IQueryable<Discount> SearchDiscounts(string searchQuery);

        Task<SavedDiscount> GetSavedDiscountAsync(int discountId, int userId);

        SavedDiscount CreateSavedDiscount(Discount discount, User user);
    }
}
