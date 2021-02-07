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

        public async Task<IEnumerable<Discount>> GetClosestActiveDiscountsAsync(GeoCoordinate location)
        {
            var activeDiscounts = await _entities.Where(d => d.ActivityStatus == true).ToListAsync();

            return activeDiscounts.Where(d => d.PointOfSales.Min(p => location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude))) < 500000);
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

        public async Task<IEnumerable<Discount>> SearchDiscounts(string searchQuery, string[] tags, GeoCoordinate location)
        {
            var searchResults = _context.Discounts.AsQueryable().Where(d => d.ActivityStatus == true);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchResults = searchResults.Where(d => d.Name.Contains(searchQuery) || d.Description.Contains(searchQuery) || d.Vendor.Name.Contains(searchQuery));
            }

            if (tags.Length != 0)
            {
                foreach (var tag in tags)
                {
                    searchResults = searchResults.Where(d => d.Tags.Select(t => t.Name).Contains(tag));
                }
            }

            await searchResults.ToListAsync();

            return searchResults.Where(d => d.PointOfSales.Min(p => location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude))) < 500000);
        }
    }
}