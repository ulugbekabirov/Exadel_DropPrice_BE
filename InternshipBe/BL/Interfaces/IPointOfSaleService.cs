using BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IPointOfSaleService
    {
        Task<IEnumerable<PointOfSaleDTO>> GetPointOfSales();
    }
}
