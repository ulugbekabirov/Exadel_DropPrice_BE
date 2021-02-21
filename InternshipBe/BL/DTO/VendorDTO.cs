namespace BL.DTO
{
    public class VendorDTO
    {
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }
        
        public string Phone { get; set; }

        public string Address { get; set; }

        public string SocialLinks { get; set; }

        public double? VendorRating { get; set; }

        public int TicketCount { get; set; }

        public int? ImageId { get; set; }

        public PointOfSaleDTO[] PointOfSales { get; set; }
    }
}
