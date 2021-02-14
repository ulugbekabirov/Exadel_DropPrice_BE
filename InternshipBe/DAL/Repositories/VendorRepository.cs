using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VendorRepository: Repository<Vendor>, IVendorRepository 
    {
        public VendorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<Vendor> SearchVendors(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return _context.Vendors;
            }

            return _context.Vendors.Where(v => v.Name.Contains(searchQuery));
        }

        public IQueryable<Discount> GetVendorDiscounts(int id)
        {
            return _context.Discounts.Where(d => d.VendorId == id);
        }

        public IOrderedQueryable<Vendor> SortBy(IQueryable<Vendor> vendors, Sorts sortBy)
        => sortBy switch
        {
            Sorts.RatingAsc => vendors.OrderBy(v => v.Discounts.Average(d => d.Assessments.Average(a => a.AssessmentValue))),
            Sorts.RatingDesc => vendors.OrderByDescending(v => _context.Assessments.Where(a => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(a.DiscountId)).Average(a => a.AssessmentValue)),
            Sorts.TicketCountAsc => vendors.OrderBy(v => v.Discounts.Sum(d => d.Tickets.Count)),
            Sorts.TicketCountDesc => vendors.OrderByDescending(v => v.Discounts.Sum(d => d.Tickets.Count)),
            _ => vendors.OrderByDescending(v => v.Discounts.Average(d => d.Assessments.Average(a => a.AssessmentValue))),
        };

        public IOrderedQueryable<Vendor> ThenSortBy(IOrderedQueryable<Vendor> vendors, Sorts sortBy)
        => sortBy switch
        {
            Sorts.RatingAsc => vendors.ThenBy(v => v.Discounts.Average(d => d.Assessments.Average(a => a.AssessmentValue))),
            Sorts.RatingDesc => vendors.ThenByDescending(v => v.Discounts.Average(d => d.Assessments.Average(a => a.AssessmentValue))),
            Sorts.TicketCountAsc => vendors.ThenBy(v => v.Discounts.Sum(d => d.Tickets.Count)),
            Sorts.TicketCountDesc => vendors.ThenByDescending(v => _context.Tickets.Where(t => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(t.DiscountId)).Count()),
            _ => vendors.ThenByDescending(v => v.Discounts.Sum(d => d.Tickets.Count)),
        };

        public async Task<double?> GetVendorRatingAsync(int id)
        {
            return await _context.Assessments.Where(a => _context.Discounts.Where(d => d.VendorId == id).Select(d => d.Id).Contains(a.DiscountId))
                .AverageAsync(a => a.AssessmentValue);
        }

        public async Task<int> GetVendorTicketCountAsync(int id)
        {
            return await _context.Tickets.Where(t => _context.Discounts.Where(d => d.VendorId == id).Select(d => d.Id).Contains(t.DiscountId))
                .CountAsync();
        }
    }
}
