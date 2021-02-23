using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("User")]
    public class User : IdentityUser<int>
    {
        public User()
        {
            SavedDiscounts = new List<SavedDiscount>();
            Tickets = new List<Ticket>();
            Assessments = new List<Assessment>();
        }

        public int OfficeId { get; set; }

        public virtual Office Office { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public bool ActivityStatus { get; set; }

        public virtual ICollection<SavedDiscount> SavedDiscounts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}