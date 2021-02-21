using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Vendor
    {
        public Vendor()
        {
            Discounts = new List<Discount>();
            PointOfSales = new List<PointOfSale>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public string SocialLinks { get; set; }

        public int? ImageId { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }

        public virtual ICollection<PointOfSale> PointOfSales { get; set; }
    }
}
