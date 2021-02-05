using BL.DTO;
using BL.Models;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorDTO>> GetVendorsAsync();

        Task<VendorDTO> GetVendorByIdAsync(int vendorId);

        Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(VendorModel vendorModel, User user);
    }
}
