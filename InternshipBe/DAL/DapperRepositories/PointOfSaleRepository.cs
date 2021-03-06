using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DapperRepositories
{
    public class PointOfSaleRepository : Repository<PointOfSale>, IPointOfSaleRepository
    {
        public Task<IEnumerable<PointOfSale>> GetExistingPointOfSalesAsync(IEnumerable<string> pointOfSalesName)
        {
            throw new NotImplementedException();
        }
    }
}
