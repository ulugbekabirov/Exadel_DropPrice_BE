using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<IEnumerable<PointOfSale>> GetPointOfSalesAsync(int id);
        Task<int> GetTotalNumberOfVendorsAsync(IQueryable<Vendor> vendors);

        IQueryable<Discount> GetVendorDiscounts(int id);

        Task<double?> GetVendorRatingAsync(int id);

        Task<int> GetVendorTicketCountAsync(int id);

        IQueryable<Vendor> SearchVendors(string searchQuery);

        IOrderedQueryable<Vendor> SortBy(IQueryable<Vendor> vendors, SortTypes sortBy);

        IOrderedQueryable<Vendor> ThenSortBy(IOrderedQueryable<Vendor> vendors, SortTypes sortBy);
    }
}
