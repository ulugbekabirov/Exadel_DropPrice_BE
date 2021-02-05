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

        public async Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(VendorModel vendorModel, User user)
        {
            var vendor = await _vendorRepository.GetByIdAsync(vendorModel.VendorId);

            var location = new GeoCoordinate(user.Office.Latitude, user.Office.Longitude);

            if (vendorModel.Latitude != 0 && vendorModel.Longitude != 0)
            {
                location = new GeoCoordinate(vendorModel.Latitude, vendorModel.Longitude);
            }

            var discountsModels = vendor.Discounts
                .Select(d => d.CreateDiscountModel(location, user.Id))
                .OrderBy(d => d.PointOfSaleDTO.DistanceInMeters)
                .Skip(vendorModel.Skip)
                .Take(vendorModel.Take);

            var disocuntDTOs = _mapper.Map<DiscountDTO[]>(discountsModels);
                
            return SortModel.SortDiscountsBy(disocuntDTOs, (Sorts)Enum.Parse(typeof(Sorts), vendorModel.SortBy));
        }
    }
}
