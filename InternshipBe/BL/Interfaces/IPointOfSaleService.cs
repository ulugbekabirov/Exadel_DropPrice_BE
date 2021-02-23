using BL.DTO;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IPointOfSaleService
    {
        Task<IEnumerable<PointOfSaleDTO>> GetPointOfSalesAsync();

        Task<List<PointOfSale>> GetPointOfSalesAndCreateIfNotExistAsync(PointOfSale[] pointOfSales);
    }
}
