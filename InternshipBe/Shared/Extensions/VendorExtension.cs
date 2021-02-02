using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ExceptionHandling.Extensions
{
    public static class VendorExtension
    {
        public static double? GetRating(this Vendor vendor)
        {
            var number = vendor.Discounts.Select(d => d.Assessments.Count);
            if (vendor.Discounts.Count == 0)
            {

            }
            return vendor.Discounts.Select(d => d.Assessments.Average(a => a.AssessmentValue)).Average(a => a);
        }
    }
}
