using System;
using System.Collections.Generic;
using BL.DTO;
using BL.Interfaces;
namespace BL.Services
{
    public class DiscountService : IDiscountService
    {
        IEnumerable<DiscountDTO> IDiscountService.GetClosestDiscounts(int skip, int take, double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
