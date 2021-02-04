using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using GeoCoordinatePortable;
using System.Collections.Generic;
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
            return _context.SavedDiscounts.FirstOrDefault(d => d.DiscountId == discountId && d.UserId == userId);
        }

        public IQueryable<Discount> SearchDiscounts(string searchQuery)
        {
            return _context.Discounts.Where(d => d.Name.Contains(searchQuery) || d.Description.Contains(searchQuery) || d.Vendor.Name.Contains(searchQuery));
        }
    }
}