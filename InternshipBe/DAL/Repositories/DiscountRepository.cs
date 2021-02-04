using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<SavedDiscount> GetSavedDiscountAsync(int discountId, int userId)
        {
            return await _context.SavedDiscounts.SingleOrDefaultAsync(s => s.DiscountId == discountId && s.UserId == userId);
        }

        public async Task<SavedDiscount> CreateSavedDiscountAsync(Discount discount, User user)
        {
            var newSavedDiscount = new SavedDiscount()
            {
                UserId = user.Id,
                DiscountId = discount.Id,
                User = user,
                Discount = discount,
                IsSaved = true,
            };

            user.SavedDiscounts.Add(newSavedDiscount);
            discount.SavedDiscounts.Add(newSavedDiscount);
            await _context.SaveChangesAsync();
            return newSavedDiscount;
        }

        public IQueryable<Discount> SearchDiscounts(string searchQuery)
        {
            return _context.Discounts.Where(d => d.Name.Contains(searchQuery) || d.Description.Contains(searchQuery) || d.Vendor.Name.Contains(searchQuery));
        }
    }
}