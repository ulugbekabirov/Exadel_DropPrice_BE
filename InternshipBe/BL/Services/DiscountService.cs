using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTO;
using BL.Interfaces;
namespace BL.Services
{
    class DiscountService : IDiscountService
    {
        IEnumerable<DiscountDTO> IDiscountService.GetClosestDiscounts(int skip, int take, double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
