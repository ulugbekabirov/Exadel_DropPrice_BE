using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Office
    {
        public Office()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
