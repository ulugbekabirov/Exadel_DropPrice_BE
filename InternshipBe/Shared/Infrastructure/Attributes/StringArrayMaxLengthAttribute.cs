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
            if (value is List<string> ListOfStrings)
            {
                foreach (var str in ListOfStrings)
                {
                    if (str.Length > Length)
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}
