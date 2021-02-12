using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<IEnumerable<Vendor>> SearchVendors(string searchQuery);
    }
}
