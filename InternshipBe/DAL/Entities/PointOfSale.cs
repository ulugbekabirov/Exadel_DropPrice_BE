using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class PointOfSale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<Discount> Discounts { get; set; }

        public PointOfSale()
        {
            Discounts = new List<Discount>();
        }
    }
}
