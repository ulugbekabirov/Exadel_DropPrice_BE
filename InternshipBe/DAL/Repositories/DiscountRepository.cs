using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Discount> GetDiscount(int skip, int take, double latitude, double longitude)
        {
            GeoCoordinate location = new GeoCoordinate(latitude, longitude);

            var pointOfSales = _context.PointOfSales
                .Select(c => new { Id = c.Id, Location = location.GetDistanceTo(new GeoCoordinate(latitude, longitude)) })
                .OrderBy(p => p.Location);

            var allDiscount = _entities.Where(d => pointOfSales.Select(p => p.Id).Contains(d.Id)).Skip(skip).Take(take);

            throw new NotImplementedException();
        }

        public IEnumerable<Discount> SearchDiscountsByDiscountName(int skip, int take, double latitude, double longitude, string DiscountName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> SearchDiscountsByTagName(int skip, int take, double latitude, double longitude, string TagName)
        {
            throw new NotImplementedException();
        }
    }
}
