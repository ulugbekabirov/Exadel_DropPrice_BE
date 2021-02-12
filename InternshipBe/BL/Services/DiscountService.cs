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
using Microsoft.EntityFrameworkCore;
using Shared.ViewModels;
using WebApi.ViewModels;

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
        private readonly ITagService _tagRepository;
        private readonly IPointOfSaleService _pointOfSaleService;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, ITagService tagRepository, IPointOfSaleService pointOfSaleService, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _tagRepository = tagRepository;
            _pointOfSaleService = pointOfSaleService;
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

        public async Task<IEnumerable<DiscountDTO>> SearchDiscountsAsync(SearchModel searchModel, User user)
        {
            if (string.IsNullOrWhiteSpace(searchModel.SearchQuery) && searchModel.Tags.Length == 0)
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

        public async Task<DiscountViewModel> CreateDiscountWithPointOfSalesAndTagsAsync(DiscountViewModel discountViewModel)
        {
            using var transaction = await _discountRepository.BeginTrancation();

            try
            {
                var discount = _mapper.Map<Discount>(discountViewModel);

                var vendorDiscount = await _discountRepository.GetVendorByNameAsync(discountViewModel.VendorName);

                var tags = await _tagRepository.GetTagsAndCreateIfNotExistAsync(discountViewModel.Tags);

                var pointOfSales = await _pointOfSaleService.GetPointOfSalesAndCreateIfNotExistAsync(_mapper.Map<PointOfSale[]>(discountViewModel.PointOfSales));

                discount.VendorId = vendorDiscount.Id;
                discount.Vendor = vendorDiscount;
                discount.Tags = tags;
                discount.PointOfSales = pointOfSales;

                await _discountRepository.CreateAsync(discount);

                await _discountRepository.SaveChangesAsync();

                var createDiscountViewModel = _mapper.Map<DiscountViewModel>(discount);
                createDiscountViewModel.Tags = discountViewModel.Tags;
                createDiscountViewModel.PointOfSales = _mapper.Map<PointOfSaleViewModel[]>(pointOfSales);

                await transaction.CommitAsync();

                return createDiscountViewModel;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<DiscountViewModel> UpdateDiscountAsync(DiscountViewModel discountViewModel)
        {
            using var transaction = await _discountRepository.BeginTrancation();

            try
            {
                var discount = await _discountRepository.GetByIdAsync(discountViewModel.Id);

                var vendorDiscount = await _discountRepository.GetVendorByNameAsync(discountViewModel.VendorName);

                var tags = await _tagRepository.GetTagsAndCreateIfNotExistAsync(discountViewModel.Tags);

                var pointOfSales = await _pointOfSaleService.GetPointOfSalesAndCreateIfNotExistAsync(_mapper.Map<PointOfSale[]>(discountViewModel.PointOfSales));

                discount.Tags.Clear();
                discount.PointOfSales.Clear();

                await _discountRepository.SaveChangesAsync();

                discount.Name = discountViewModel.DiscountName;
                discount.VendorId = vendorDiscount.Id;
                discount.Vendor = vendorDiscount;
                discount.Description = discountViewModel.Description;
                discount.PromoCode = discountViewModel.PromoCode;
                discount.DiscountAmount = discountViewModel.DiscountAmount;
                discount.ActivityStatus = discountViewModel.ActivityStatus;
                discount.StartDate = discountViewModel.StartDate;
                discount.EndDate = discountViewModel.EndDate;
                discount.Tags = tags;
                discount.PointOfSales = pointOfSales;

                await _discountRepository.SaveChangesAsync();

                await transaction.CommitAsync();

                var createDiscountViewModel = _mapper.Map<DiscountViewModel>(discount);
                createDiscountViewModel.Tags = discount.Tags.Select(t => t.Name).ToArray();
                createDiscountViewModel.PointOfSales = _mapper.Map<PointOfSaleViewModel[]>(pointOfSales);

                return createDiscountViewModel;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<AssessmentViewModel> UpdateUserAssessmentForDiscountAsync(int id, AssessmentViewModel assessmentViewModel, User user)
        {
            var assessment = await _discountRepository.GetUserAssessmentAsync(id, user.Id);

            if (assessment is null)
            {
                var discount = await _discountRepository.GetByIdAsync(id);
                assessment = await _discountRepository.CreateAssessmentAsync(discount, user, assessmentViewModel.AssessmentValue);
            }
            else
            {
                assessment.AssessmentValue = assessmentViewModel.AssessmentValue;
            }

            await _discountRepository.SaveChangesAsync();

            return _mapper.Map<AssessmentViewModel>(assessment);
        }

        public async Task<IEnumerable<DiscountStatisticDTO>> SearchDiscountsForStatisticsAsync(AdminSearchModel adminSearchModel)
        {
            var discounts = await _discountRepository.SearchDiscountsStatisticsAsync(adminSearchModel.SearchQuery).ToListAsync();

            var discountStatisticDTOs = _mapper.Map<DiscountStatisticDTO[]>(discounts);

            var ordereDiscountStatisticDTOs = discountStatisticDTOs.SortBy(adminSearchModel.SortBy[0]).ThenSortBy(adminSearchModel.SortBy[1]);

            return ordereDiscountStatisticDTOs.Skip(adminSearchModel.Skip).Take(adminSearchModel.Take);
        }
    }
}
