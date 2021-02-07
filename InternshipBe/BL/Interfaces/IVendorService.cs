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

        Task<VendorDTO> GetVendorByIdAsync(int id);

        Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(int id, SortModel vendorModel, User user);
    }
}
