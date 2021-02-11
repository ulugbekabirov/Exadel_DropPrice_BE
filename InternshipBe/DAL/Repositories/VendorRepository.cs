using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;

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
                return _context.Vendors.AsQueryable();
            }

            return _context.Vendors.Where(v => v.Name.Contains(searchQuery)).AsQueryable();
        }
    }
}
