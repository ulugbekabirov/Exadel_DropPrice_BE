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
        }

        public int Id { get; set; }

        public int Vendorid { get; set; }

        public Vendor Vendor { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(40)]
        public string Description { get; set; }

        [Required]
        public int DiscountAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool ActivityStatus { get; set; } = true;

        public string Promocode { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<PointOfSale> PointOfSales { get; set; }

        public ICollection<Assessment> Assessments { get; set; }
    }
}
