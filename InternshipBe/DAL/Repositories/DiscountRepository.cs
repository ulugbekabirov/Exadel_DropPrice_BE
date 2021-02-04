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

        public IQueryable<Discount> SearchDiscounts(string searchQuery)
        {
            return _context.Discounts.Where(d => d.Name.Contains(searchQuery) || d.Description.Contains(searchQuery) || d.Vendor.Name.Contains(searchQuery));
        }

        public async Task<Discount> UpdateUserSave(int discountId, User user)
        {
            var savedDiscount = user.SavedDiscounts.FirstOrDefault(s => s.DiscountId == discountId && s.UserId == user.Id);

            var discount = await _context.Discounts.FindAsync(discountId);

            if (savedDiscount is null)
            {
                var newSavedDiscount = new SavedDiscount()
                {
                    UserId = user.Id,
                    DiscountId = discountId,
                    User = user,
                    Discount = discount,
                    
                };

                user.SavedDiscounts.Add(newSavedDiscount);
                discount.SavedDiscounts.Add(newSavedDiscount);
            }
            else
            {
                _context.SavedDiscounts.Remove(savedDiscount);
            }

            await _context.SaveChangesAsync();

            return discount;
        }
    }
}