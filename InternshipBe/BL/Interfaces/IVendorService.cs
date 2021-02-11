using BL.DTO;
using BL.Models;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace BL.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorDTO>> GetVendorsAsync();

        Task<VendorDTO> GetVendorByIdAsync(int id);

        Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(int id, SortModel vendorModel, User user);

        Task<VendorViewModel> CreateVendorAsync(VendorViewModel vendorViewModel);

        Task<VendorViewModel> UpdateVendorAsync(VendorViewModel vendorViewModel);

        Task<IEnumerable<VendorDTO>> SearchAsync(SearchModel searchModel, User user);
    }
}
