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

        public async Task<IEnumerable<Vendor>> SearchVendors(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return await _context.Vendors.ToListAsync();
            }

            return await _context.Vendors.Where(v => v.Name.Contains(searchQuery)).ToListAsync();
        }
    }
}
