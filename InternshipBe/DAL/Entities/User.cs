using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public User()
        {
            SavedDiscounts = new List<SavedDiscount>();
            Tickets = new List<Ticket>();
        }

        [Required]
        public Office Office { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string Patronymic { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public bool ActivityStatus { get; set; }

        public ICollection<SavedDiscount> SavedDiscounts { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}