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
        public string SortBy { get; set; } = "DistanceDesc";

        public static IEnumerable<DiscountDTO> SortDiscountsBy(IEnumerable<DiscountDTO> discounts, Sorts sortBy)
            => sortBy switch
            {
                Sorts.AlphabetAsc => discounts.OrderBy(d => d.DistanceInMeters).ThenBy(d => d.DiscountName),
                Sorts.AlphabetDesc => discounts.OrderBy(d => d.DistanceInMeters).ThenByDescending(d => d.DiscountName),
                Sorts.DiscountRatingAsc => discounts.OrderBy(d => d.DistanceInMeters).ThenBy(d => d.DiscountRating),
                Sorts.DiscountRatingDesc => discounts.OrderBy(d => d.DistanceInMeters).ThenByDescending(d => d.DiscountRating),
                Sorts.DistanceAsc => discounts.OrderBy(d => d.DistanceInMeters),
                Sorts.DistanceDesc => discounts.OrderByDescending(d => d.DistanceInMeters),
                _ => discounts.OrderBy(d => d.DistanceInMeters),
            };

    }
}
