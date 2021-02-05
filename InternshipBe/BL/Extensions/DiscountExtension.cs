using BL.DTO;
using BL.Models;
using DAL.Entities;
using GeoCoordinatePortable;
using Shared.Extensions;
using System.Linq;

namespace BL.Extensions
{
    public static class DiscountExtension
    {
        public static DiscountModel CreateDiscountModel(this Discount discount, GeoCoordinate location, int userId)
        {
            var discountModel = new DiscountModel()
            {
                Discount = discount,
                DiscountRating = discount.DiscountRating(),
                PointOfSaleDTO = discount.GetPointOfSaleDTO(location),
                IsSaved = discount.IsSavedDiscount(userId),
                Tags = discount.GetTags(),
            };

            return discountModel;
        }

        public static PointOfSaleDTO GetPointOfSaleDTO(this Discount discount, GeoCoordinate location)
        {
            if (discount.PointOfSales.Count == 0)
            {
                return null;
            }

            var pointOfSaleDTO = discount.PointOfSales
                .Select(p => new PointOfSaleDTO()
                {
                    Address = p.Address,
                    DistanceInMeters = (int)location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude))
                })
                .OrderBy(p => p.DistanceInMeters)
                .FirstOrDefault();

            return pointOfSaleDTO;
        }
    }
}
