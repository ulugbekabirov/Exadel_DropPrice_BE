using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<Discount> SearchDiscounts(string searchQuery)
        {
            return _context.Discounts.Where(d => d.Name.Contains(searchQuery) || d.Description.Contains(searchQuery) || d.Vendor.Name.Contains(searchQuery));
        }

        public async Task<SavedDiscount> UpdateUserSaveAsync(int discountId, User user)
        {
            var savedDiscount = _context.SavedDiscounts.SingleOrDefault(s => s.DiscountId == discountId && s.UserId == user.Id);

            var discount = await GetByIdAsync(discountId);

            if (savedDiscount is null)
            {
                var newSavedDiscount = new SavedDiscount()
                {
                    UserId = user.Id,
                    DiscountId = discountId,
                    User = user,
                    Discount = discount,
                    IsSaved = true,
                };

                user.SavedDiscounts.Add(newSavedDiscount);
                discount.SavedDiscounts.Add(newSavedDiscount);
            }
            else
            {
                savedDiscount.IsSaved = !savedDiscount.IsSaved;
            }

            await _context.SaveChangesAsync();

            return savedDiscount;
        }
    }
}