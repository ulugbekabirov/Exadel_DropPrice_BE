using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class Ticket
    {
        public int Id { get; set; }
        public Discount Discount { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
