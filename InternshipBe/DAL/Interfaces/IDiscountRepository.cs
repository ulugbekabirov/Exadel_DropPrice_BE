using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        Task<(IQueryable<ICollection<Discount>>, Dictionary<int, double>)> GetClosestDiscountsAsync(double latitude, double longitude);
    }
}
