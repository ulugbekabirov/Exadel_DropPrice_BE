using Shared.Properties;
using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels
{
    public class ConfigViewModel
    {
        [Required(ErrorMessageResourceName = "ConfigIdIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ConfigValueIsEmpty", ErrorMessageResourceType = typeof(ValidationResource))]
        public string Value { get; set; }
    }
}
