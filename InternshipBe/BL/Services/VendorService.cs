using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace BL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IDiscountService _discountSevice;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public VendorService(IVendorRepository vendorRepository, IDiscountRepository discountRepository, IDiscountService discountSevice, IMapper mapper, IImageRepository imageRepository)
        {
            _vendorRepository = vendorRepository;
            _discountRepository = discountRepository;
            _discountSevice = discountSevice;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task AddRatingAndTicketCountToVendorAsync(VendorDTO vendorDTO)
        {
            vendorDTO.TicketCount = await _vendorRepository.GetVendorTicketCountAsync(vendorDTO.VendorId);
            vendorDTO.VendorRating = await _vendorRepository.GetVendorRatingAsync(vendorDTO.VendorId);
        }

        public async Task<VendorDTO> GetVendorByIdAsync(int id)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id);

            var vendorDTO = _mapper.Map<VendorDTO>(vendor);

            await AddRatingAndTicketCountToVendorAsync(vendorDTO);

            return vendorDTO;
        }

        public async Task<IEnumerable<VendorDTO>> GetVendorsAsync()
        {
            var vendors = await _vendorRepository.GetAllAsync();

            var vendorDTOs = _mapper.Map<VendorDTO[]>(vendors);

            for (int i = 0; i < vendorDTOs.Length; i++)
            {
                await AddRatingAndTicketCountToVendorAsync(vendorDTOs[i]);
            }

            return vendorDTOs;
        }

        public async Task<IEnumerable<DiscountDTO>> GetVendorDiscountsAsync(int id, SortModel sortModel, User user)
        {
            var location = _vendorRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, sortModel.Latitude, sortModel.Longitude);

            var sortBy = _discountRepository.GetSortType(sortModel.SortBy);

            var discounts = _vendorRepository.GetVendorDiscounts(id);

            var sortedDiscounts = _discountRepository.SortDiscounts(discounts, sortBy, location);

            var specifiedAmountDiscounts = await _discountRepository.GetSpecifiedAmountAsync(sortedDiscounts, sortModel.Skip, sortModel.Take);

            var discountDTOs = _mapper.Map<DiscountDTO[]>(specifiedAmountDiscounts);

            for (int i = 0; i < discountDTOs.Length; i++)
            {
                await _discountSevice.AddCompositePropertiesToDiscountDTOAsync(user.Id, discountDTOs[i], location);
            }

            return discountDTOs;
        }

        public async Task<VendorViewModel> CreateVendorAsync(VendorViewModel vendorViewModel)
        {
            var vendor = _mapper.Map<Vendor>(vendorViewModel);

            await _vendorRepository.CreateAsync(vendor);

            return _mapper.Map<VendorViewModel>(vendor);
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

        public async Task<TotalVendorDTO> SearchVendorsAsync(AdminSearchModel adminSearchModel)
        {
            var searchVendors = _vendorRepository.SearchVendors(adminSearchModel.SearchQuery);

            var sortBy = _discountRepository.GetSortType(adminSearchModel.SortBy[0]);
            var thenSortBy = _discountRepository.GetSortType(adminSearchModel.SortBy[1]);

            var orderedVendorDTOs = _vendorRepository.SortBy(searchVendors, sortBy);
            orderedVendorDTOs = _vendorRepository.ThenSortBy(orderedVendorDTOs, thenSortBy);

            var specifiedAmountDiscounts = await _vendorRepository.GetSpecifiedAmountAsync(orderedVendorDTOs, adminSearchModel.Skip, adminSearchModel.Take);

            var vendorDTOs = _mapper.Map<VendorDTO[]>(specifiedAmountDiscounts);

            for (int i = 0; i < vendorDTOs.Length; i++)
            {
                await AddRatingAndTicketCountToVendorAsync(vendorDTOs[i]);
            }

            TotalVendorDTO totalVendorDTO = new TotalVendorDTO()
            {
                VendorDTOs = vendorDTOs,
                TotalNumberOfVendors = await _vendorRepository.GetTotalNumberOfVendorsAsync(searchVendors),
            };

            return totalVendorDTO;
        }

        public async Task<VendorDTO> AddImageToVendorAsync(IFormFile file, int vendorId)
        {
            var vendor = await _vendorRepository.GetByIdAsync(vendorId);

            var filename = file.FileName;

            var extension = Path.GetExtension(filename);

            var allowedExtensions = new string[] { ".jpeg", ".png", ".jpg" };

            if (allowedExtensions.Contains(extension))
            {
                var ms = new MemoryStream();
                file.CopyTo(ms);
                var imageData = ms.ToArray();
                var image = await _imageRepository.CreateAndReturnImageAsync(imageData, filename);
                vendor.ImageId = image.Id;
                await _vendorRepository.SaveChangesAsync();
            }

            return _mapper.Map<VendorDTO>(vendor);
        }

    }
}
