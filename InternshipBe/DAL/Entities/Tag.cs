using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Tag  
    {
        public Tag()
        {
            Discounts = new List<Discount>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Discount> Discounts { get; set; }
    }
}
