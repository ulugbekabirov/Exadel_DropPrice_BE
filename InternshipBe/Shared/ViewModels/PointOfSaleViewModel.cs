using Shared.Properties;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class PointOfSaleViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessageResourceName = "PointOfSaleNameIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "PointOfSaleAddressIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceName = "PointOfSaleLatitudeIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public double? Latitude { get; set; }

        [Required(ErrorMessageResourceName = "PointOfSaleLongitudeIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public double? Longitude { get; set; }
    }
}