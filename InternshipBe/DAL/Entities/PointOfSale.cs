using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PointOfSale
    {
        public PointOfSale()
        {
            Discounts = new List<Discount>();
            Vendors = new List<Vendor>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public Point Location { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }

        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
