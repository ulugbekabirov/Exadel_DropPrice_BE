using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using DAL.Interfaces;
using NetTopologySuite.Geometries;
using Shared.Infrastructure;
using Shared.ViewModels;
using WebApi.ViewModels;

namespace BL.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IHangfireService _hangfireService;
        private readonly ITagService _tagRepository;
        private readonly IPointOfSaleService _pointOfSaleService;
        private readonly IMapper _mapper;
        private readonly IConfigRepository _configRepository;

        public DiscountService(IDiscountRepository discountRepository, IVendorRepository vendorRepository, IHangfireService hangfireService, ITagService tagRepository, IPointOfSaleService pointOfSaleService, IMapper mapper, IConfigRepository configRepository)
        {
            _discountRepository = discountRepository;
            _vendorRepository = vendorRepository;
            _hangfireService = hangfireService;
            _tagRepository = tagRepository;
            _pointOfSaleService = pointOfSaleService;
            _mapper = mapper;
            _configRepository = configRepository;
        }

        public async Task<IEnumerable<DiscountDTO>> GetDiscountsAsync(SortModel sortModel, User user)
        {
            var location = _discountRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, sortModel.Latitude, sortModel.Longitude);

            var sortBy = _discountRepository.GetSortType(sortModel.SortBy);

            var radius = await _configRepository.GetRadiusAsync((int)ConfigIdentifiers.Radius);
                
            var closestActiveDiscounts = _discountRepository.GetClosestActiveDiscounts(location, radius);

            var sortedDiscounts = _discountRepository.SortDiscounts(closestActiveDiscounts, sortBy, location);

            var specifiedAmountDiscounts = await _discountRepository.GetSpecifiedAmountAsync(sortedDiscounts, sortModel.Skip, sortModel.Take);

            var discountDTOs = _mapper.Map<DiscountDTO[]>(specifiedAmountDiscounts);

            for (int i = 0; i < discountDTOs.Length; i++)
            {
                await AddCompositePropertiesToDiscountDTOAsync(user.Id, discountDTOs[i], location);
            }

            return discountDTOs;
        }

        public async Task<DiscountDTO> GetDiscountByIdAsync(int id, LocationModel locationModel, User user)
        {
            var location = _discountRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, locationModel.Latitude, locationModel.Longitude);

            var discount = await _discountRepository.GetByIdAsync(id);

            var discountDTO = _mapper.Map<DiscountDTO>(discount);

            await AddCompositePropertiesToDiscountDTOAsync(user.Id, discountDTO, location);

            return discountDTO;
        }

        public async Task<IEnumerable<DiscountDTO>> SearchDiscountsAsync(SearchModel searchModel, User user)
        {
            if (string.IsNullOrWhiteSpace(searchModel.SearchQuery) && searchModel.Tags.Length == 0)
            {
                return await GetDiscountsAsync(searchModel, user);
            }

            var location = _discountRepository.GetLocation(user.Office.Latitude, user.Office.Longitude, searchModel.Latitude, searchModel.Longitude);

            var sortBy = _discountRepository.GetSortType(searchModel.SortBy);

            var radius = await _configRepository.GetRadiusAsync((int)ConfigIdentifiers.Radius);

            var discounts =  _discountRepository.SearchDiscounts(searchModel.SearchQuery, searchModel.Tags, location, radius);

            var sortedDiscounts = _discountRepository.SortDiscounts(discounts, sortBy, location);

            var specifiedAmountDiscounts = await _discountRepository.GetSpecifiedAmountAsync(sortedDiscounts, searchModel.Skip, searchModel.Take);

            var discountDTOs = _mapper.Map<DiscountDTO[]>(specifiedAmountDiscounts);

            for (int i = 0; i < discountDTOs.Length; i++)
            {
                await AddCompositePropertiesToDiscountDTOAsync(user.Id, discountDTOs[i], location);
            }

            return discountDTOs;
        }

        public async Task AddCompositePropertiesToDiscountDTOAsync(int userId, DiscountDTO discountDTO, Point location)
        {
            var assessment = await _discountRepository.GetUserAssessmentAsync(discountDTO.DiscountId, userId);

            var (Address, Distance) = await _discountRepository.GetInformationOfPointOfSaleAsync(discountDTO.DiscountId, location);

            discountDTO.DiscountRating = await _discountRepository.GetDiscountRatingAsync(discountDTO.DiscountId);
            discountDTO.Tags = await _discountRepository.GetDiscountTagsAsync(discountDTO.DiscountId);
            discountDTO.IsSaved = await _discountRepository.IsSavedDiscountAsync(discountDTO.DiscountId, userId);
            discountDTO.IsOrdered = await _discountRepository.IsOrderedDiscountAsync(discountDTO.DiscountId, userId);
            discountDTO.AssessmentValue = assessment?.AssessmentValue;
            discountDTO.Address = Address;
            discountDTO.DistanceInMeters = Distance;
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

        public async Task<ArchivedDiscountDTO> ArchiveOrUnarchiveDiscountAsync(int id)
        {
            var discount = await _discountRepository.GetByIdAsync(id);
            discount.ActivityStatus = !discount.ActivityStatus;

            if (!discount.ActivityStatus)
            {
                _hangfireService.DeleteDiscountEditJob(discount.Id);
            }

            await _discountRepository.SaveChangesAsync();

            return _mapper.Map<ArchivedDiscountDTO>(discount);
        }

        public async Task<DiscountViewModel> CreateDiscountWithPointOfSalesAndTagsAsync(DiscountViewModel discountViewModel)
        {
            using var transaction = await _discountRepository.BeginTrancation();

            try
            {
                var discount = _mapper.Map<Discount>(discountViewModel);

                var vendorDiscount = await _vendorRepository.GetByIdAsync(discountViewModel.VendorId);

                var tags = await _tagRepository.GetTagsAndCreateIfNotExistAsync(discountViewModel.Tags);

                var pointOfSales = _mapper.Map<PointOfSale[]>(discountViewModel.PointOfSales);
                
                var resultPointOfSales = await _pointOfSaleService.GetPointOfSalesAndCreateIfNotExistAsync(pointOfSales);

                discount.VendorId = vendorDiscount.Id;
                discount.Vendor = vendorDiscount;
                discount.Tags = tags;
                discount.PointOfSales = resultPointOfSales;

                await _discountRepository.CreateAsync(discount);

                await _discountRepository.SaveChangesAsync();

                var createDiscountViewModel = _mapper.Map<DiscountViewModel>(discount);
                createDiscountViewModel.Tags = discountViewModel.Tags;
                createDiscountViewModel.PointOfSales = _mapper.Map<PointOfSaleViewModel[]>(resultPointOfSales);

                await transaction.CommitAsync();

                return createDiscountViewModel;
            }
            catch
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
                var discount = await _discountRepository.GetByIdAsync(discountViewModel.DiscountId);

                var tags = await _tagRepository.GetTagsAndCreateIfNotExistAsync(discountViewModel.Tags);

                var pointOfSales = _mapper.Map<PointOfSale[]>(discountViewModel.PointOfSales);

                var resultPointOfSales = await _pointOfSaleService.GetPointOfSalesAndCreateIfNotExistAsync(pointOfSales);

                discount.Tags.Clear();
                discount.PointOfSales.Clear();

                await _discountRepository.SaveChangesAsync();

                discount.Name = discountViewModel.DiscountName;
                discount.Description = discountViewModel.Description;
                discount.PromoCode = discountViewModel.PromoCode;
                discount.DiscountAmount = discountViewModel.DiscountAmount;
                discount.ActivityStatus = discountViewModel.ActivityStatus;
                discount.StartDate = discountViewModel.StartDate;
                discount.EndDate = discountViewModel.EndDate;
                discount.Tags = tags;
                discount.PointOfSales = resultPointOfSales;

                await _discountRepository.SaveChangesAsync();

                await transaction.CommitAsync();

                _hangfireService.DeleteDiscountEditJob(discount.Id);

                var createDiscountViewModel = _mapper.Map<DiscountViewModel>(discount);
                createDiscountViewModel.Tags = discount.Tags.Select(t => t.Name).ToArray();
                createDiscountViewModel.PointOfSales = _mapper.Map<PointOfSaleViewModel[]>(resultPointOfSales);

                return createDiscountViewModel;
            }
            catch
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

        public async Task<TotalDiscountDTO> SearchDiscountsForStatisticsAsync(AdminSearchModel adminSearchModel)
        {
            var discounts = _discountRepository.SearchStatisticDiscountsAsync(adminSearchModel.SearchQuery);

            var sortBy = _discountRepository.GetSortType(adminSearchModel.SortBy[0]);
            var thenSortBy = _discountRepository.GetSortType(adminSearchModel.SortBy[1]);

            var sortedDiscounts = _discountRepository.SortBy(discounts, sortBy);
            sortedDiscounts = _discountRepository.ThenSortBy(sortedDiscounts, thenSortBy);

            var specifiedAmountDiscounts = await _discountRepository.GetSpecifiedAmountAsync(sortedDiscounts, adminSearchModel.Skip, adminSearchModel.Take);

            var statisticDiscountDTOs = _mapper.Map<DiscountStatisticDTO[]>(specifiedAmountDiscounts);

            for (int i = 0; i < specifiedAmountDiscounts.Count(); i++)
            {
                var discountId = specifiedAmountDiscounts.ElementAt(i).Id;
                statisticDiscountDTOs[i].DiscountRating = await _discountRepository.GetDiscountRatingAsync(discountId);
                statisticDiscountDTOs[i].TicketCount = await _discountRepository.GetDiscountTicketCountAsync(discountId);
            }

            TotalDiscountDTO totalDiscountDTO = new TotalDiscountDTO()
            {
                DiscountDTOs = statisticDiscountDTOs,
                TotalNumberOfDiscounts = await _discountRepository.GetTotalNumberOfDiscountsAsync(discounts),
            };

            return totalDiscountDTO;
        }

        public async Task<IEnumerable<PointOfSaleDTO>> GetPointOfSalesAsync(int id)
        {
            var pointOfSales = await _discountRepository.GetPointOfSalesAsync(id);

            return _mapper.Map<PointOfSaleDTO[]>(pointOfSales);
        }

        public async Task<IEnumerable<string>> GetSearchHintsAsync(string subSearchQuery, SpecifiedAmountModel specifiedAmountModel)
        {
            return await _discountRepository.SearchHintsAsync(subSearchQuery, specifiedAmountModel.Take);
        }
    }
}
