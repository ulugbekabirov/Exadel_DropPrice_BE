using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Discount
    {
        public Discount()
        {
            Tags = new List<Tag>();
            PointOfSales = new List<PointOfSale>();
            Assessments = new List<Assessment>();
            SavedDiscounts = new List<SavedDiscount>();
            Tickets = new List<Ticket>();
        }

        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int DiscountAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool ActivityStatus { get; set; }

        public string PromoCode { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<PointOfSale> PointOfSales { get; set; }

        public virtual ICollection<SavedDiscount> SavedDiscounts { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
