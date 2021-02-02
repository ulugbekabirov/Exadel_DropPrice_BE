using DAL.Entities;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Linq;

namespace BL.Extensions
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
            return discount.SavedDiscounts.Any(sd => sd.DiscountId == discount.Id && sd.UserId == userId);
        }

        public static double? DiscountRating(this Discount discount)
        {
            if (discount.Assessments.Count == 0)
            {
                return null;
            }

            return discount.Assessments.Average(a => a.AssessmentValue);
        }

        public static (string, int?) GetAddressAndDistanceOfPointOfSale(this Discount discount, GeoCoordinate location)
        {
            if (discount.PointOfSales.Count == 0)
            {
                return (null, null);
            }

            var pointOfSale = discount.PointOfSales
                .Select(p => new { Address = p.Address, Distance = (int)location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)) })
                .OrderBy(p => p.Distance).FirstOrDefault();

            return (pointOfSale.Address, pointOfSale.Distance);
        }
    }
}
