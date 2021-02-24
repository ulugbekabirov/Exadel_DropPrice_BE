using BL.DTO;
using BL.Models;
using DAL.Entities;
using NetTopologySuite.Geometries;
using Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace BL.Interfaces
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountDTO>> GetDiscountsAsync(SortModel sortModel, User user);

        Task<IEnumerable<DiscountDTO>> SearchDiscountsAsync(SearchModel searchModel, User user);

        Task<DiscountDTO> GetDiscountByIdAsync(int id, LocationModel locationModel, User user);

        Task<SavedDTO> SaveOrUnsaveDisocuntAsync(int id, User user);

        Task<ArchivedDiscountDTO> ArchiveOrUnarchiveDiscountAsync(int id);

        Task<DiscountViewModel> CreateDiscountWithPointOfSalesAndTagsAsync(DiscountViewModel discountViewModel);

        Task<DiscountViewModel> UpdateDiscountAsync(DiscountViewModel discountViewModel);

        Task<AssessmentViewModel> UpdateUserAssessmentForDiscountAsync(int id, AssessmentViewModel assessmentViewModel, User user);

        Task<TotalDiscountDTO> SearchDiscountsForStatisticsAsync(AdminSearchModel adminSearchModel);

        Task<IEnumerable<PointOfSaleDTO>> GetPointOfSalesAsync(int id);

        Task AddCompositePropertiesToDiscountDTOAsync(int userId, DiscountDTO discountDTOs, Point location);

        Task<IEnumerable<string>> GetSearchHintsAsync(string subSearchQuery, SpecifiedAmountModel specifiedAmountModel);
    }
}
