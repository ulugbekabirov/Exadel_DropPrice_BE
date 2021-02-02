using DAL.Entities;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace BL.Models
{
    public class DiscountModel
    {
        public Discount Discount { get; set; }

        public int UserId { get; set; }

        public GeoCoordinate Location { get; set; }
    }
}
