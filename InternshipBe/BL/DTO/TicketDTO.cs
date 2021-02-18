using System;

namespace BL.DTO
{
    public class TicketDTO
    {
        public int DiscountId { get; set; }

        public int VendorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string VendorName { get; set; }

        public string DiscountName { get; set; }

        public string VendorEmail { get; set; }

        public string VendorPhone { get; set; }

        public string PromoCode { get; set; }

        public int DiscountAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public bool IsExpired { get; set; }

        public bool DiscountActivity { get; set; }

        public bool IsSavedDiscount { get; set; }
    }
}
