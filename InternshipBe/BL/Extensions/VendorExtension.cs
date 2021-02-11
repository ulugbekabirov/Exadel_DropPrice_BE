using BL.DTO;
using BL.Extensions;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Extensions
{
    public static class VendorExtension
    {
        public static double? GetVendorRating(this Vendor vendor)
        {
            return vendor.Discounts.Select(d => d.DiscountRating()).Average(a => a);
        }

        public static int GetTicketCount(this Vendor vendor)
        {
            return vendor.Discounts.Sum(d => d.Tickets.Count);
        }

        public static IOrderedEnumerable<VendorDTO> SortBy(this IEnumerable<VendorDTO> vendors, bool sortBy)
        => sortBy switch
        {
            true => vendors.OrderBy(d => d.VendorRating),
            false => vendors.OrderByDescending(v => v.VendorRating),
        };

        public static IOrderedEnumerable<VendorDTO> ThenSortBy(this IOrderedEnumerable<VendorDTO> vendors, bool sortBy)
        => sortBy switch
        {
            true => vendors.ThenBy(d => d.TicketCount),
            false => vendors.ThenByDescending(v => v.TicketCount),
        };
    }
}
