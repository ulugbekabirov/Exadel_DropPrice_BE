using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        (IQueryable<ICollection<Discount>>, Dictionary<int, double>) GetClosestDiscounts(double latitude, double longitude);
    }
}
