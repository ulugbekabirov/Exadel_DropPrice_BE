using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Discount>> GetSpecifiedClosestActiveDiscounts(GeoCoordinate location, int skip, int take)
        {
            var activeDiscounts = await _entities.Where(d => d.ActivityStatus == true).ToListAsync();

            return activeDiscounts.
                OrderBy(d => d.PointOfSales
                    .Select(p => location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)))
                    .OrderBy(p => p)
                    .FirstOrDefault())
                .Skip(skip)
                .Take(take);
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

            await _context.SavedDiscounts.AddAsync(newSavedDiscount);
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