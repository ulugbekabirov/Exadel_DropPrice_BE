using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            if (value is not List<string>)
                return false;

            foreach (var str in value as List<string>)
            {
                if (str.Length > Length)
                    return false;
            }

            return true;
        }
    }
}
