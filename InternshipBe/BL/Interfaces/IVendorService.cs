using BL.DTO;
using BL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
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

        Task<TotalVendorDTO> SearchVendorsAsync(AdminSearchModel searchModel);
        Task<VendorDTO> AddImageToVendorAsync(IFormFile file, int vendorId);

    }
}
