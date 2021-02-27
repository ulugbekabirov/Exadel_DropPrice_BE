using Shared.Properties;
using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
    public class AssessmentViewModel
    {
        [Required(ErrorMessageResourceName = "DiscountAssessmentValueIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public int? AssessmentValue { get; set; }
    }
}
