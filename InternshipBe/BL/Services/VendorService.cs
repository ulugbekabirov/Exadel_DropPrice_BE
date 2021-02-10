using AutoMapper;
using BL.DTO;
using BL.Extensions;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace BL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IMapper _mapper;
        public VendorService(IRepository<Vendor> vendorRepository, IMapper mapper)
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

        public async Task<VendorViewModel> CreateVendor(VendorViewModel vendorViewModel)
        {
            var vendor = _mapper.Map<Vendor>(vendorViewModel);

            await _vendorRepository.CreateAsync(vendor);

            var vendorViewModelCreated = _mapper.Map<VendorViewModel>(vendor); 

            return vendorViewModelCreated;
        }
    }
}
