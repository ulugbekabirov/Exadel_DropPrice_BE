using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Town
    {
        public int Id { get; set; }

        [Required]
        public virtual LocalizedName Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
