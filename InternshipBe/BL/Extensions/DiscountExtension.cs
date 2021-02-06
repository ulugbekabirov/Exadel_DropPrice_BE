using BL.DTO;
using BL.Models;
using BL.Services;
using DAL.Entities;
using GeoCoordinatePortable;
using Shared.Extensions;
using System.Collections.Generic;
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

        public static IEnumerable<DiscountModel> SortDiscountsBy(this IEnumerable<DiscountModel> discounts, Sorts sortBy)
            => sortBy switch
            {
                Sorts.AlphabetAsc => discounts.OrderBy(d => d.Discount.Name).ThenBy(d => d.PointOfSaleDTO.DistanceInMeters),
                Sorts.AlphabetDesc => discounts.OrderByDescending(d => d.Discount.Name).ThenBy(d => d.PointOfSaleDTO.DistanceInMeters),
                Sorts.DiscountRatingAsc => discounts.OrderBy(d => d.DiscountRating).ThenBy(d => d.PointOfSaleDTO.DistanceInMeters),
                Sorts.DiscountRatingDesc => discounts.OrderByDescending(d => d.DiscountRating).ThenBy(d => d.PointOfSaleDTO.DistanceInMeters),
                Sorts.DistanceAsc => discounts.OrderBy(d => d.PointOfSaleDTO.DistanceInMeters),
                Sorts.DistanceDesc => discounts.OrderByDescending(d => d.PointOfSaleDTO.DistanceInMeters),
                _ => discounts.OrderBy(d => d.PointOfSaleDTO.DistanceInMeters),
            };
    }
}
