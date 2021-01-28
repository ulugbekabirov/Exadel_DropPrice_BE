using BL.DTO;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface IDiscountService 
    {
        IEnumerable<DiscountDTO> GetClosestDiscounts(int skip, int take, double latitude, double longitude);
    }
}
