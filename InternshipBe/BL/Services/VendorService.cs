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

        public async Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(int id, SortModel sortModel, User user)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);

            var location = new GeoCoordinate(user.Office.Latitude, user.Office.Longitude);

            if (sortModel.Latitude != 0 && sortModel.Longitude != 0)
            {
                location = new GeoCoordinate(sortModel.Latitude, sortModel.Longitude);
            }

            var discountsModels = vendor.Discounts
                .Select(d => d.CreateDiscountModel(location, user.Id))
                .OrderBy(d => d.PointOfSaleDTO.DistanceInMeters)
                .Skip(sortModel.Skip)
                .Take(sortModel.Take);

            var disocuntDTOs = _mapper.Map<DiscountDTO[]>(discountsModels);
                
            return SortModel.SortDiscountsBy(disocuntDTOs, (Sorts)Enum.Parse(typeof(Sorts), sortModel.SortBy));
        }
    }
}
