using BL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Extensions
{
    public static class DiscountExtension
    {
        public static List<string> GetTags(this Discount discount)
        {
            if (discount.Tags.Count == 0)
            {
                return new List<string>();
            }

            return discount.Tags.Select(t => t.Name).ToList();
        }
    }
}
