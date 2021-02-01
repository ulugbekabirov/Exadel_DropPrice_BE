using System;

namespace BL.DTO
{
    public class DiscountDTO
    {
        public int DiscountId { get; set; }

        public int VendorId { get; set; }

        public string DiscountName { get; set; }

        public string VendorName { get; set; }

        public int DistanceInMeters { get; set; }

        public int DiscountRating { get; set; }

        public int DiscountAmount { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsSaved { get; set; }
    }
}
