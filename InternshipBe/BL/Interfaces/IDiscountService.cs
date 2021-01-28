using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IDiscountService 
    {
        IEnumerable<DiscountDTO> GetClosestDiscounts(int skip, int take, double latitude, double longitude);
    }
}
