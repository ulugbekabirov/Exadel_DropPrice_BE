using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IQueryable<Discount>> GetClosestDiscounts(int skip, int take, double latitude, double longitude)
        {
            var location = new GeoCoordinate(latitude, longitude);

            var closestPointsOfSales = _context.PointOfSales
                .OrderBy(p => location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)));

            var discounts = await GetSpecifiedAmount(skip, take);

            return discounts.Where(d => closestPointsOfSales.Select(p => p.Id).Contains(d.Id));
        }
    }
}
