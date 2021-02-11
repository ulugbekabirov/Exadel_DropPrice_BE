using DAL.Entities;
using System.Linq;

namespace DAL.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        IQueryable<Vendor> SearchVendors(string searchQuery);
    }
}
