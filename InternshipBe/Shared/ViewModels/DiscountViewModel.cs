using Shared.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class DiscountViewModel
    {
        public int DiscountId { get; set; }

        [Required(ErrorMessageResourceName = "DiscountVendorId", ErrorMessageResourceType = typeof(ValidationResource))]
        public int? VendorId { get; set; }

        public string VendorName { get; set; }

        [Required(ErrorMessageResourceName = "DiscountName", ErrorMessageResourceType = typeof(ValidationResource))]
        public string DiscountName { get; set; }

        [Required(ErrorMessageResourceName = "DiscountDescription", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "DiscountAmount", ErrorMessageResourceType = typeof(ValidationResource))]
        public int? DiscountAmount { get; set; }

        public string PromoCode { get; set; }

        [Required(ErrorMessageResourceName = "StartDate", ErrorMessageResourceType = typeof(ValidationResource))]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessageResourceName = "EndDate", ErrorMessageResourceType = typeof(ValidationResource))]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessageResourceName = "ActivityStatus", ErrorMessageResourceType = typeof(ValidationResource))]
        public bool? ActivityStatus { get; set; }

        public string[] Tags { get; set; }

        public PointOfSaleViewModel[] PointOfSales { get; set; }
    }
}
