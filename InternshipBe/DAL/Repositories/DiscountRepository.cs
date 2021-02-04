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

        public SavedDiscount GetSavedDiscount(int discountId, int userId)
        {
            return _context.SavedDiscounts.SingleOrDefault(s => s.DiscountId == discountId && s.UserId == userId);
        }

        public SavedDiscount CreateSavedDiscount(Discount discount, User user)
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
            _context.SaveChanges();
            return newSavedDiscount;
        }

        public IQueryable<Discount> SearchDiscounts(string searchQuery)
        {
            return _context.Discounts.Where(d => d.Name.Contains(searchQuery) || d.Description.Contains(searchQuery) || d.Vendor.Name.Contains(searchQuery));
        }
    }
}