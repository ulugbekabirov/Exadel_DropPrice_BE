using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public Discount Discount { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
