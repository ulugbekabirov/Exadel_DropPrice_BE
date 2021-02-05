using BL.DTO;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorDTO>> GetVendorsAsync();

        Task<VendorDTO> GetVendorByIdAsync(int vendorId);

        Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(int vendorId, User user);
    }
}
