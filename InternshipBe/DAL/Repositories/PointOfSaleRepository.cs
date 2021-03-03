using DAL.DataContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PointOfSaleRepository : Repository<PointOfSale>, IPointOfSaleRepository
    {
        public PointOfSaleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PointOfSale>> GetExistingPointOfSalesAsync(IEnumerable<string> pointOfSalesName)
        {
            return await _context.PointOfSales.Where(p => pointOfSalesName.Contains(p.Name)).AsNoTracking().ToListAsync();
        }
    }
}
