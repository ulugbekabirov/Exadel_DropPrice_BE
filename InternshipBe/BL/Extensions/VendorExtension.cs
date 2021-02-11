using BL.DTO;
using BL.Extensions;
using DAL.Entities;
using System;
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

        public static IOrderedEnumerable<VendorDTO> SortBy(this IEnumerable<VendorDTO> vendors, string sortBy)
        => sortBy switch
        {
            "RatingAsc" => vendors.OrderBy(v => v.VendorRating),
            "RatingDesc" => vendors.OrderByDescending(v => v.VendorRating),
            "TicketCountAsc" => vendors.OrderBy(v => v.TicketCount),
            "TicketCountDesc" => vendors.OrderByDescending(v => v.TicketCount),
            _ => throw new NotImplementedException(),
        };

        public static IOrderedEnumerable<VendorDTO> ThenSortBy(this IOrderedEnumerable<VendorDTO> vendors, string sortBy)
        => sortBy switch
        {
            "RatingAsc" => vendors.ThenBy(v => v.VendorRating),
            "RatingDesc" => vendors.ThenByDescending(v => v.VendorRating),
            "TicketCountAsc" => vendors.ThenBy(v => v.TicketCount),
            "TicketCountDesc" => vendors.ThenByDescending(v => v.TicketCount),
            _ => throw new NotImplementedException(),
        };
    }
}
