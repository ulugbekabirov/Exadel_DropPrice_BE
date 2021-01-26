using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class SavedDiscount
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public Discount Discount { get; set; }
    }
}
