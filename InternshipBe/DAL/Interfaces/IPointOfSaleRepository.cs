using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPointOfSaleRepository : IRepository<PointOfSale>
    {
        Task<IEnumerable<PointOfSale>> GetExistingPointOfSalesAsync(IEnumerable<string> pointOfSalesName);
    }
}