using DAL.Entities;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Extensions
{
    public static class DiscountExtension
    {
        public static List<string> GetTags(this Discount discount)
        {
            if (discount.Tags.Count == 0)
            {
                return new List<string>();
            }

            return discount.Tags.Select(t => t.Name).ToList();
        }

        public static bool IsSavedDiscount(this Discount discount, int userId)
        {
            var savedDiscount = discount.SavedDiscounts.SingleOrDefault(s => s.DiscountId == discount.Id && s.UserId == userId);

            if (savedDiscount is null)
            {
                return false;
            }

            return savedDiscount.IsSaved;
        }

        public static double? DiscountRating(this Discount discount)
        {
            if (discount.Assessments.Count == 0)
            {
                return null;
            }

            return discount.Assessments.Average(a => a.AssessmentValue);
        }
    }
}
