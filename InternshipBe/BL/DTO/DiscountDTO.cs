using System;
using System.Collections.Generic;

namespace BL.DTO
{
    public class DiscountDTO
    {
        public int DiscountId { get; set; }

        public int VendorId { get; set; }

        public string DiscountName { get; set; }

        public string VendorName { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int? DistanceInMeters { get; set; }

        public double? DiscountRating { get; set; }

        public string PromoCode { get; set; }

        public int DiscountAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool ActivityStatus { get; set; }

        public bool IsSaved { get; set; }

        public bool IsOrdered { get; set; }

        public int? AssessmentValue { get; set; }

        public ICollection<string> Tags { get; set; } 
    }
}
