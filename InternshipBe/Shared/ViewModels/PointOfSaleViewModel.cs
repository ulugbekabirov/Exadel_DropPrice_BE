using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class PointOfSaleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the pointOfSale's Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the pointOfSale's Address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the pointOfSale's Latitude.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Please enter the pointOfSale's Longitude.")]
        public double Longitude { get; set; }
    }
}