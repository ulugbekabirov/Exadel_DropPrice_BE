using Shared.Properties;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class PointOfSaleViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessageResourceName = "PointOfSaleName", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "PointOfSaleAddress", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceName = "PointOfSaleLatitude", ErrorMessageResourceType = typeof(ValidationResource))]
        public double? Latitude { get; set; }

        [Required(ErrorMessageResourceName = "PointOfSaleLongitude", ErrorMessageResourceType = typeof(ValidationResource))]
        public double? Longitude { get; set; }
    }
}