using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IHangfireService
    {
        Task<string> BeginDiscountEditJobAsync(int discountId);

        Task<string> EndDiscountEditJobAsync(int discountId);
    }
}
