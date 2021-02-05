using DAL.Entities;
using System.Linq;

namespace Shared.Extensions
{
    public static class VendorExtension
    {
        public static double? GetVendorRating(this Vendor vendor)
        {
            return vendor.Discounts.Select(d => d.DiscountRating()).Average(a=>a);
        }
    }
}
