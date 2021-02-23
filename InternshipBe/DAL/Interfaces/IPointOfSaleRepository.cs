using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPointOfSaleRepository : IRepository<PointOfSale>
    {
        Task<IEnumerable<PointOfSale>> GetExistingPointOfSalesAsync(IEnumerable<string> pointOfSalesName);
    }
}