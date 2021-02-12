using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Assessment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public virtual User User { get; set; }

        public int DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public int? AssessmentValue { get; set; }
    }
}
