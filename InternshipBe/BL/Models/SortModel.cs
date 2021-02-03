using BL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BL.Models
{
    public enum Sorts
    {
        DiscountRatingAsc,
        DiscountRatingDesc,
        DistanceAsc,
        DistanceDesc,
        AlphabetAsc,
        AlphabetDesc,
    }

    public class SortModel : LocationModel
    {
        public string SortBy { get; set; } = "DistanceAsc";

        public static IEnumerable<DiscountDTO> SortDiscountsBy(DiscountDTO[] discounts, Sorts sortBy)
            => sortBy switch
            {
                Sorts.AlphabetAsc => discounts.OrderBy(d => d.DiscountName).ThenBy(d => d.DistanceInMeters),
                Sorts.AlphabetDesc => discounts.OrderByDescending(d => d.DiscountName).ThenBy(d => d.DistanceInMeters),
                Sorts.DiscountRatingAsc => discounts.OrderBy(d => d.DiscountRating).ThenBy(d => d.DistanceInMeters),
                Sorts.DiscountRatingDesc => discounts.OrderByDescending(d => d.DiscountRating).ThenBy(d => d.DistanceInMeters),
                Sorts.DistanceAsc => discounts.OrderBy(d => d.DistanceInMeters),
                Sorts.DistanceDesc => discounts.OrderByDescending(d => d.DistanceInMeters),
                _ => discounts.OrderBy(d => d.DistanceInMeters),
            };
    }
}
