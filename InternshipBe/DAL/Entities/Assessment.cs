using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Assessment
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public int DiscountId { get; set; }

        public Discount Discount { get; set; }

        [Required]
        public int AssessmentValue { get; set; }
    }
}
