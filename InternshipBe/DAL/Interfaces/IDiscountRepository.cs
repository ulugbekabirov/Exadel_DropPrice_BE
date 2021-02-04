using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        IQueryable<Discount> SearchDiscounts(string searchQuery);

        Task<SavedDiscount> GetSavedDiscountAsync(int discountId, int userId);

        Task<SavedDiscount> CreateSavedDiscountAsync(Discount discount, User user);
    }
}
