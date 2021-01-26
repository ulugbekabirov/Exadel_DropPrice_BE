using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Vendor
    {
        public Vendor()
        {
            Discounts = new List<Discount>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string SocialNetworkLink { get; set; }

        public ICollection<Discount> Discounts { get; set; }
    }
}
