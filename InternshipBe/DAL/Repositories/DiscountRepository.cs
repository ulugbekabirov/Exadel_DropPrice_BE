using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System;
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

        public IQueryable<Discount> GetClosestActiveDiscounts(Point location, int radius)
        {
            return _entities.Where(d => d.ActivityStatus == true && d.PointOfSales.Min(p => p.Location.Distance(location)) < radius);
        }

        public IQueryable<Discount> SearchDiscounts(string searchQuery, int[] tagIDs, Point location, int radius)
        {
            var searchResults = _context.Discounts.Where(d => d.ActivityStatus == true);

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchResults = searchResults.Where(d => d.Name.Contains(searchQuery) || d.Description.Contains(searchQuery) || d.Vendor.Name.Contains(searchQuery));
            }

            if (tagIDs.Length != 0)
            {
                foreach (var tagID in tagIDs)
                {
                    searchResults = searchResults.Where(d => d.Tags.Select(t => t.Id).Contains(tagID));
                }
            };

            return searchResults.Where(d => d.PointOfSales.Min(p => p.Location.Distance(location)) < radius);
        }

        public IQueryable<Discount> SortDiscounts(IQueryable<Discount> discounts, SortTypes sortBy, Point location)
        {
            var sortedDiscounts = sortBy switch
            {
                SortTypes.RatingAsc => discounts.OrderBy(d => d.Assessments.Average(a => a.AssessmentValue)),
                SortTypes.RatingDesc => discounts.OrderByDescending(d => d.Assessments.Average(a => a.AssessmentValue)),
                SortTypes.DistanceAsc => discounts.OrderBy(d => d.PointOfSales.Min(p => p.Location.Distance(location))),
                SortTypes.DistanceDesc => discounts.OrderByDescending(d => d.PointOfSales.Min(p => p.Location.Distance(location))),
                SortTypes.AlphabetAsc => discounts.OrderBy(d => d.Name),
                SortTypes.AlphabetDesc => discounts.OrderByDescending(d => d.Name),
                _ => discounts.OrderBy(d => d.PointOfSales.Min(p => p.Location.Distance(location))),
            };

            if (sortBy == SortTypes.DistanceAsc || sortBy == SortTypes.DistanceDesc)
            {
                return sortedDiscounts;
            }

            return sortedDiscounts.ThenBy(d => d.PointOfSales.Min(p => p.Location.Distance(location)));
        }

        public async Task<double?> GetDiscountRatingAsync(int id)
        {
            return await _context.Assessments.Where(d => d.DiscountId == id).AverageAsync(d => d.AssessmentValue);
        }

        public async Task<ICollection<string>> GetDiscountTagsAsync(int id)
        {
            return await _context.Tags.Where(t => t.Discounts.Select(d => d.Id).Contains(id)).Select(t => t.Name).ToListAsync();
        }

        public async Task<bool> IsSavedDiscountAsync(int id, int userId)
        {
            return await _context.SavedDiscounts.AnyAsync(s => s.DiscountId == id && s.UserId == userId && s.IsSaved == true);
        }

        public async Task<bool> IsOrderedDiscountAsync(int id, int userId)
        {
            return await _context.Tickets.AnyAsync(t => t.DiscountId == id && t.UserId == userId);
        }

        public async Task<(string, int)> GetAddressAndDistanceToClosestPointOfSaleAsync(int id, Point location)
        {
            var pointOfSale = await _context.Discounts.Where(d => d.Id == id)
                .Select(d => d.PointOfSales
                    .Select(p => new { p.Address, DistanceBetweenPoints = p.Location.Distance(location) })
                    .OrderBy(p => p.DistanceBetweenPoints)
                    .FirstOrDefault())
                .FirstAsync();

            return (pointOfSale.Address, (int)pointOfSale.DistanceBetweenPoints);
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

            await _context.SaveChangesAsync();

            return newSavedDiscount;
        }

        public async Task<Assessment> GetUserAssessmentAsync(int discountId, int userId)
        {
            return await _context.Assessments.SingleOrDefaultAsync(a => a.DiscountId == discountId && a.UserId == userId);
        }

        public async Task<Assessment> CreateAssessmentAsync(Discount discount, User user, int assessmentValue)
        {
            var assessment = new Assessment()
            {
                DiscountId = discount.Id,
                UserId = user.Id,
                Discount = discount,
                User = user,
                AssessmentValue = assessmentValue,
            };

            await _context.Assessments.AddAsync(assessment);

            await _context.SaveChangesAsync();

            return assessment;
        }

        public IQueryable<Discount> SearchStatisticDiscountsAsync(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return  _context.Discounts;
            }

            return _context.Discounts.Where(v => v.Name.Contains(searchQuery));
        }

        public IOrderedQueryable<Discount> SortBy(IQueryable<Discount> discounts, SortTypes sortBy)
        => sortBy switch
        {
            SortTypes.RatingAsc => discounts.OrderBy(d => d.Assessments.Average(a => a.AssessmentValue)),
            SortTypes.RatingDesc => discounts.OrderByDescending(d => d.Assessments.Average(a => a.AssessmentValue)),
            SortTypes.TicketCountAsc => discounts.OrderBy(d => d.Tickets.Count),
            SortTypes.TicketCountDesc => discounts.OrderByDescending(d => d.Tickets.Count),
            _ => discounts.OrderByDescending(d => d.Assessments.Average(a => a.AssessmentValue)),
        };

        public IOrderedQueryable<Discount> ThenSortBy(IOrderedQueryable<Discount> discounts, SortTypes sortBy)
        => sortBy switch
        {
            SortTypes.RatingAsc => discounts.ThenBy(d => d.Assessments.Average(a => a.AssessmentValue)),
            SortTypes.RatingDesc => discounts.ThenByDescending(d => d.Assessments.Average(a => a.AssessmentValue)),
            SortTypes.TicketCountAsc => discounts.ThenBy(d => d.Tickets.Count),
            SortTypes.TicketCountDesc => discounts.ThenByDescending(d => d.Tickets.Count),
            _ => discounts.ThenByDescending(d => d.Tickets.Count),
        };

        public async Task<int> GetDiscountTicketCountAsync(int id)
        {
            return await _context.Tickets.CountAsync(t => t.DiscountId == id);
        }

        public async Task<IEnumerable<PointOfSale>> GetPointOfSalesAsync(int id)
        {
            var discount = await GetByIdAsync(id);

            return discount.PointOfSales.ToList();
        }

        public async Task<int> GetTotalNumberOfDiscountsAsync(IQueryable<Discount> discounts)
        {
            return await discounts.CountAsync();
        }

        public async Task<IEnumerable<string>> SearchHintsAsync(string subSearchQuery, int take)
        {
            return await _entities.Where(d => d.Name.Contains(subSearchQuery) || d.Vendor.Name.Contains(subSearchQuery)).Take(take).Select(d => d.Name).ToListAsync();
        }

        public async Task UpdateDiscountActivityStatusAsync(int id, bool activityStatus)
        {
            var discount = await GetByIdAsync(id);

            discount.ActivityStatus = activityStatus;

            await SaveChangesAsync();
        }
    }
}