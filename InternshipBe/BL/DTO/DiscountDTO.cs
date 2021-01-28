using System;

namespace BL.DTO
{
    public class DiscountDTO
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string DiscountName { get; set; }

        public string VendorName { get; set; }

        public int Distance { get; set; }

        public int DiscountRaing { get; set; }

        public int VendorRating { get; set; }

        public int DiscountAmount { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsSaved { get; set; }
    }
}
