using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
