using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTO;
using BL.Extensions;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions;

namespace BL.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository,
                                IMapper mapper)
        {
            _discountRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiscountDTO>> GetClosestDiscountsAsync(SortModel sortModel, User user)
        {
            var location = new GeoCoordinate(sortModel.Latitude, sortModel.Longitude);

            var closestDiscounts = await _discountRepository.GetSpecifiedClosestActiveDiscounts(location, sortModel.Skip, sortModel.Take);
                
            var discountModels = closestDiscounts.Select(d => d.CreateDiscountModel(location, user.Id));

            var discountDTOs = _mapper.Map<DiscountDTO[]>(discountModels);

            return SortModel.SortDiscountsBy(discountDTOs, (Sorts)Enum.Parse(typeof(Sorts), sortModel.SortBy));
        }

        public async Task<IEnumerable<DiscountDTO>> SearchAsync(string searchQuery)
        {
            var discounts = await _discountRepository.SearchDiscounts(searchQuery).ToListAsync();

            return _mapper.Map<DiscountDTO[]>(discounts);
        }

        public async Task<DiscountDTO> GetDiscountByIdAsync(int discountId, User user)
        {
            var discount = await _discountRepository.GetByIdAsync(discountId);

            var discountModel = discount.CreateDiscountModel(new GeoCoordinate(user.Office.Latitude, user.Office.Longitude), user.Id);

            return _mapper.Map<DiscountDTO>(discountModel);
        }

        public async Task<SavedDTO> SaveOrUnsaveDisocuntAsync(int discountId, User user)
        {
            var savedDiscount = await _discountRepository.GetSavedDiscountAsync(discountId, user.Id);

            if (savedDiscount is null)
            {
                var discount = await _discountRepository.GetByIdAsync(discountId);
                savedDiscount = await _discountRepository.CreateSavedDiscountAsync(discount, user);
            }
            else
            {
                savedDiscount.IsSaved = !savedDiscount.IsSaved;
                await _discountRepository.SaveChangesAsync();
            }

            return _mapper.Map<SavedDTO>(savedDiscount);
        }
    }
}
