using DAL.Entities;
using DAL.Repositories;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        IQueryable<Discount> SearchDiscounts(string searchQuery, string[] tags, Point location, int radius);

        Task<SavedDiscount> GetSavedDiscountAsync(int id, int userId);

        Task<SavedDiscount> CreateSavedDiscountAsync(Discount discount, User user);

        IQueryable<Discount> GetClosestActiveDiscountsAsync(Point location, int radius);

        Task<Vendor> GetVendorByNameAsync(string vendorName);

        Task<Assessment> GetUserAssessmentAsync(int id, int userId);

        Task<Assessment> CreateAssessmentAsync(Discount discount, User user, int assessmnetValue);

        IQueryable<Discount> SearchStatisticDiscountsAsync(string searchQuery);

        IQueryable<Discount> GetSortedDiscountsAsync(IQueryable<Discount> discounts, Sorts sortBy, Point location);

        Task<IEnumerable<Discount>> GetSpecifiedAmountAsync(IQueryable<Discount> discounts, int skip, int take);

        Task<double?> GetDiscountRatingAsync(int id);

        Task<ICollection<string>> GetDiscountTagsAsync(int id);

        Task<bool> IsSavedDiscountAsync(int id, int userId);

        Task<bool> IsOrderedDiscountAsync(int id, int userId);

        Task<(string, int)> GetInformationOfPointOfSaleAsync(int id, Point location);

        IOrderedQueryable<Discount> SortBy(IQueryable<Discount> discounts, Sorts sortBy);

        IOrderedQueryable<Discount> ThenSortBy(IOrderedQueryable<Discount> discounts, Sorts sortBy);

        Task<int> GetDiscountTicketCountAsync(int id);
    }
}
