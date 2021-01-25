using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class Discount
    {
        public int Id { get; set; }
        public int IdVendor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ActivityStatus { get; set; }
        public string Promocode { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public Discount()
        {
            Tags = new List<Tag>();
        }
    }
}
