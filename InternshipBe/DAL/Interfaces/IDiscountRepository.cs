using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        Task<IQueryable<Discount>> GetClosestDiscountsAsync(int skip, int take, double latitude, double longitude);
    }
}
