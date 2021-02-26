using Shared.Properties;
using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
    public class AssessmentViewModel
    {
        [Required(ErrorMessageResourceName = "DiscountAssessmentValue", ErrorMessageResourceType = typeof(ValidationResource))]
        public int? AssessmentValue { get; set; }
    }
}
