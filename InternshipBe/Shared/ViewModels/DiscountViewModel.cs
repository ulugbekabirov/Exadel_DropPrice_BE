using Shared.Infrastructure.Attributes;
using Shared.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class DiscountViewModel
    {
        public int DiscountId { get; set; }

        [Required(ErrorMessageResourceName = "DiscountVendorIdIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public int? VendorId { get; set; }

        public string VendorName { get; set; }

        [Required(ErrorMessageResourceName = "DiscountNameIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        [MaxLength(200, ErrorMessageResourceName = "DiscountNameExceededMaxLength", ErrorMessageResourceType = typeof(ValidationResource))]
        public string DiscountName { get; set; }

        [Required(ErrorMessageResourceName = "DiscountDescriptionIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "DiscountAmountIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public int? DiscountAmount { get; set; }

        public string PromoCode { get; set; }

        [Required(ErrorMessageResourceName = "StartDateIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessageResourceName = "EndDateIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessageResourceName = "ActivityStatusIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public bool? ActivityStatus { get; set; }

        [StringArrayMaxLength(200)]
        public string[] Tags { get; set; }

        public PointOfSaleViewModel[] PointOfSales { get; set; }
    }
}
