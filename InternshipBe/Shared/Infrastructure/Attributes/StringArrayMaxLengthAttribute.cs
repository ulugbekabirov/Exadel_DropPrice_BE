using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Shared.Infrastructure.Attributes
{
    public class StringArrayMaxLengthAttribute : MaxLengthAttribute
    {
        public StringArrayMaxLengthAttribute(int Length)
            :base(Length)
        {
        }

        public override bool IsValid(object value)
        {
            if (value is string[] ListOfStrings)
            {
                return ListOfStrings.All(l => l.Length < Length);
            }

            return false;
        }
    }
}
