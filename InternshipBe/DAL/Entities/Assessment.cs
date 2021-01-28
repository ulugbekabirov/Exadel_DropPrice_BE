using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Assessment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        public int DiscountId { get; set; }

        public Discount Discount { get; set; }

        [Required]
        public int AssessmentValue { get; set; }
    }
}
