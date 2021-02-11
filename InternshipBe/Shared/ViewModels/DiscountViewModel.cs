using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class DiscountViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the discount's VendorName.")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "Please enter the discount's Name.")]
        public string DiscountName { get; set; }

        [Required(ErrorMessage = "Please enter the discount's Description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the discount's DiscountAmount.")]
        public int DiscountAmount { get; set; }

        public string PromoCode { get; set; }

        [Required(ErrorMessage = "Please enter the discount's StartDate.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the discount's EndDate.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please enter the discount's ActivityStatus.")]
        public bool ActivityStatus { get; set; }

        public string[] Tags { get; set; }

        public PointOfSaleViewModel[] PointOfSales { get; set; }
    }
}
