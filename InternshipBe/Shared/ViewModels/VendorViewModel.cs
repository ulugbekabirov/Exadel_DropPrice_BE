using Shared.Properties;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class VendorViewModel
    {
        [Required(ErrorMessageResourceName = "VendorId", ErrorMessageResourceType = typeof(ValidationResource))]
        public int? VendorId { get; set; }

        [Required(ErrorMessageResourceName = "VendorName", ErrorMessageResourceType = typeof(ValidationResource))]
        public string VendorName { get; set; }

        [Required(ErrorMessageResourceName = "VendorDescription", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "VendorEmail", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "VendorAddress", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceName = "VendorPhone", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Phone { get; set; }

        public string SocialLinks { get; set; }

        public PointOfSaleViewModel[] PointOfSales { get; set; }
    }
}
