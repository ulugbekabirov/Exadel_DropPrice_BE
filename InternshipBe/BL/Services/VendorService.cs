using AutoMapper;
using BL.DTO;
using BL.Extensions;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace BL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public VendorService(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorDTO> GetVendorByIdAsync(int id)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);

            return _mapper.Map<VendorDTO>(vendor);
        }

        public async Task<IEnumerable<VendorDTO>> GetVendorsAsync()
        {
            var vendors = await _vendorRepository.GetAllAsync();

            return _mapper.Map<VendorDTO[]>(vendors);
        }

        public async Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(int id, SortModel sortModel, User user)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);

            var location = _vendorRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, sortModel.Latitude, sortModel.Longitude);

            var sortBy = (Sorts)Enum.Parse(typeof(Sorts), sortModel.SortBy);

            var discountsModels = vendor.Discounts
                .Select(d => d.CreateDiscountModel(location, user.Id))
                .SortDiscountsBy(sortBy)
                .Skip(sortModel.Skip)
                .Take(sortModel.Take);

            return _mapper.Map<DiscountDTO[]>(discountsModels);
        }

        public async Task<VendorViewModel> CreateVendorAsync(VendorViewModel vendorViewModel)
        {
            var vendor = _mapper.Map<Vendor>(vendorViewModel);

            await _vendorRepository.CreateAsync(vendor);

            var vendorViewModelCreated = _mapper.Map<VendorViewModel>(vendor);

            return vendorViewModelCreated;
        }

        public async Task<VendorViewModel> UpdateVendorAsync(VendorViewModel vendorViewModel)
        {
            var vendor = await _vendorRepository.GetByIdAsync(vendorViewModel.Id);

            vendor.Name = vendorViewModel.Name;
            vendor.Phone = vendorViewModel.Phone;
            vendor.SocialLinks = vendorViewModel.SocialLinks;
            vendor.Email = vendorViewModel.Email;
            vendor.Address = vendorViewModel.Address;
            vendor.Description = vendorViewModel.Description;

            await _vendorRepository.SaveChangesAsync();

            return _mapper.Map<VendorViewModel>(vendor);
        }

        public async Task<IEnumerable<VendorDTO>> SearchVendorsAsync(AdminSearchModel searchModel)
        {
            var searchVendors = await _vendorRepository.SearchVendors(searchModel.SearchQuery).ToListAsync();

            var searchVendorDTOs = _mapper.Map<VendorDTO[]>(searchVendors);

            var orderedVendorDTOs = ThenSortBy(SortBy(searchVendorDTOs, searchModel.SortBy[0]), searchModel.SortBy[1]);

            return orderedVendorDTOs.Skip(searchModel.Skip).Take(searchModel.Take);
        }

        public IOrderedEnumerable<VendorDTO> SortBy(IEnumerable<VendorDTO> vendors, string sortBy)
        => sortBy switch
        {
            "RatingAsc" => vendors.OrderBy(v => v.VendorRating),
            "RatingDesc" => vendors.OrderByDescending(v => v.VendorRating),
            "TicketCountAsc" => vendors.OrderBy(v => v.TicketCount),
            "TicketCountDesc" => vendors.OrderByDescending(v => v.TicketCount),
            _ => throw new NotImplementedException(),
        };

        public IOrderedEnumerable<VendorDTO> ThenSortBy(IOrderedEnumerable<VendorDTO> vendors, string sortBy)
        => sortBy switch
        {
            "RatingAsc" => vendors.ThenBy(v => v.VendorRating),
            "RatingDesc" => vendors.ThenByDescending(v => v.VendorRating),
            "TicketCountAsc" => vendors.ThenBy(v => v.TicketCount),
            "TicketCountDesc" => vendors.ThenByDescending(v => v.TicketCount),
            _ => throw new NotImplementedException(),
        };
    }
}
