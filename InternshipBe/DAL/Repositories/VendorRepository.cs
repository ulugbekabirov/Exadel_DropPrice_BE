using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VendorRepository: Repository<Vendor>, IVendorRepository 
    {
        public VendorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PointOfSale>> GetPointOfSalesAsync(int id)
        {
            var vendor = await GetByIdAsync(id); 

            return vendor.PointOfSales.ToList();
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

        public IOrderedQueryable<Vendor> SortBy(IQueryable<Vendor> vendors, SortTypes sortBy)
        => sortBy switch
        {
            SortTypes.RatingAsc => vendors.OrderBy(v => _context.Assessments.Where(a => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(a.DiscountId)).Average(a => a.AssessmentValue)),
            SortTypes.RatingDesc => vendors.OrderByDescending(v => _context.Assessments.Where(a => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(a.DiscountId)).Average(a => a.AssessmentValue)),
            SortTypes.TicketCountAsc => vendors.OrderBy(v => _context.Tickets.Where(t => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(t.DiscountId)).Count()),
            SortTypes.TicketCountDesc => vendors.OrderByDescending(v => _context.Tickets.Where(t => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(t.DiscountId)).Count()),
            _ => vendors.OrderByDescending(v => _context.Assessments.Where(a => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(a.DiscountId)).Average(a => a.AssessmentValue)),
        };

        public IOrderedQueryable<Vendor> ThenSortBy(IOrderedQueryable<Vendor> vendors, SortTypes sortBy)
        => sortBy switch
        {
            SortTypes.RatingAsc => vendors.ThenBy(v => _context.Assessments.Where(a => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(a.DiscountId)).Average(a => a.AssessmentValue)),
            SortTypes.RatingDesc => vendors.ThenByDescending(v => _context.Assessments.Where(a => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(a.DiscountId)).Average(a => a.AssessmentValue)),
            SortTypes.TicketCountAsc => vendors.ThenBy(v => _context.Tickets.Where(t => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(t.DiscountId)).Count()),
            SortTypes.TicketCountDesc => vendors.ThenByDescending(v => _context.Tickets.Where(t => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(t.DiscountId)).Count()),
            _ => vendors.ThenByDescending(v => _context.Tickets.Where(t => _context.Discounts.Where(d => d.VendorId == v.Id).Select(d => d.Id).Contains(t.DiscountId)).Count()),
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

        public async Task<int> GetTotalNumberOfVendorsAsync(IQueryable<Vendor> vendors)
        {
            return await vendors.CountAsync();
        }
    }
}
