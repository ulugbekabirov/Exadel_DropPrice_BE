using BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorDTO>> GetVendorsAsync();
        Task<VendorDTO> GetVendorByIdAsync(int id);
    }
}
