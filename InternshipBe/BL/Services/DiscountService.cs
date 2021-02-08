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

namespace BL.Services
{
    public enum Sorts
    {
        DiscountRatingAsc,
        DiscountRatingDesc,
        DistanceAsc,
        DistanceDesc,
        AlphabetAsc,
        AlphabetDesc,
    }

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

        public async Task<IEnumerable<DiscountDTO>> GetDiscountsAsync(SortModel sortModel, User user)
        {
            var location = _discountRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, sortModel.Latitude, sortModel.Longitude);

            var sortBy = (Sorts)Enum.Parse(typeof(Sorts), sortModel.SortBy);

            var closestDiscounts = await _discountRepository.GetClosestActiveDiscountsAsync(location);

            var sortedDiscountModels = closestDiscounts.Select(d => d.CreateDiscountModel(location, user.Id))
                .SortDiscountsBy(sortBy)
                .Skip(sortModel.Skip)
                .Take(sortModel.Take); 

            return _mapper.Map<DiscountDTO[]>(sortedDiscountModels);
        }

        public async Task<IEnumerable<DiscountDTO>> SearchAsync(SearchModel searchModel, User user)
        {
            if (string.IsNullOrEmpty(searchModel.SearchQuery) && searchModel.Tags.Length == 0)
            {
                return await GetDiscountsAsync(searchModel, user);
            }

            var location = _discountRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, searchModel.Latitude, searchModel.Longitude);

            var sortBy = (Sorts)Enum.Parse(typeof(Sorts), searchModel.SortBy);

            var discounts = await _discountRepository.SearchDiscounts(searchModel.SearchQuery, searchModel.Tags, location);

            var sortedDiscountModels = discounts.Select(d => d.CreateDiscountModel(location, user.Id))
                                                       .SortDiscountsBy(sortBy)
                                                       .Skip(searchModel.Skip)
                                                       .Take(searchModel.Take);

            var discountDTOs = _mapper.Map<DiscountDTO[]>(sortedDiscountModels);

            return discountDTOs;
        }

        public async Task<DiscountDTO> GetDiscountByIdAsync(int id, LocationModel locationModel, User user)
        {
            var location = _discountRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, locationModel.Latitude, locationModel.Longitude);

            var discount = await _discountRepository.GetByIdAsync(id);

            var discountModel = discount.CreateDiscountModel(location, user.Id);

            return _mapper.Map<DiscountDTO>(discountModel);
        }

        public async Task<SavedDTO> SaveOrUnsaveDisocuntAsync(int id, User user)
        {
            var savedDiscount = await _discountRepository.GetSavedDiscountAsync(id, user.Id);

            if (savedDiscount is null)
            {
                var discount = await _discountRepository.GetByIdAsync(id);
                savedDiscount = await _discountRepository.CreateSavedDiscountAsync(discount, user);
            }
            else
            {
                savedDiscount.IsSaved = !savedDiscount.IsSaved;
                await _discountRepository.SaveChangesAsync();
            }

            return _mapper.Map<SavedDTO>(savedDiscount);
        }

        public async Task<ArchivedDiscountDTO> ArchiveOrUnarchiveDiscount(int id)
        {
            var discount = await _discountRepository.GetByIdAsync(id);

            discount.ActivityStatus = !discount.ActivityStatus;

            await _discountRepository.SaveChangesAsync();

            return _mapper.Map<ArchivedDiscountDTO>(discount);
        }
    }
}
