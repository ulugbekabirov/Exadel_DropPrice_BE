using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class VendorViewModel
    {

        [Required(ErrorMessage = "Please enter the vendor's VendorId.")]
        public int VendorId { get; set; }

        public string VendorName { get; set; }
        
        [Required(ErrorMessage = "Please enter the vendor's Description.")]
        public string Description { get; set; }
       
        [Required(ErrorMessage = "Please enter the vendor's Email.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter the vendor's Address.")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Please enter the vendor's Phone.")]
        public string Phone { get; set; }

        public string SocialLinks { get; set; }

        public PointOfSaleViewModel[] PointOfSales { get; set; }
    }
}
