using BL.DTO;
using DAL.Entities;
using System.Collections.Generic;

namespace BL.Models
{
    public class DiscountModel
    {
        public Discount Discount { get; set; }

        public DiscountLocationDTO PointOfSaleDTO { get; set; }

        public bool IsSaved { get; set; }

        public double? DiscountRating { get; set; }

        public List<string> Tags { get; set; }
    }
}
