using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class VendorDTO
    {
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string SocialNetworkLink { get; set; }
        
        public double? VendorRating { get; set; }
    }
}
