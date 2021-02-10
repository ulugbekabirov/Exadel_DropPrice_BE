using DAL.Entities;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        Task<IEnumerable<Discount>> SearchDiscounts(string searchQuery, string[] tags, GeoCoordinate location);

        Task<SavedDiscount> GetSavedDiscountAsync(int discountId, int userId);

        Task<SavedDiscount> CreateSavedDiscountAsync(Discount discount, User user);

        Task<IEnumerable<Discount>> GetClosestActiveDiscountsAsync(GeoCoordinate location);

        Task<Vendor> GetVendorByNameAsync(string vendorName);
    }
}
