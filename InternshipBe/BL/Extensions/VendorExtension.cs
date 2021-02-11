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
    }
}
