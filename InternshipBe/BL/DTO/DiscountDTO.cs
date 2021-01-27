using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class DiscountDTO
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string DiscountName { get; set; }

        public string VendorName { get; set; }

        public int Distance { get; set; }

        public int DiscountRaing { get; set; }

        public int VendorRating { get; set; }

        public int DiscountAmount { get; set; }

        public DateTime dateTime { get; set; }

        public bool IsSaved { get; set; }
    }
}
