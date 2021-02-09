using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public string VkLink { get; set; }

        public string TwitterLink { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
