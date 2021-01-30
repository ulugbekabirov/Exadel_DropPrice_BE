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

        public async Task<IQueryable<Discount>> GetClosestDiscountsAsync(int skip, int take, double latitude, double longitude)
        {
            var location = new GeoCoordinate(latitude, longitude);

            var closestPointsOfSales = _context.PointOfSales.ToList()
                .Select(p=> new {Id = p.Id, Discounts = p.Discounts ,Distanse = location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)) })
                .OrderBy(p=>p.Distanse);

            var closestDiscounts = closestPointsOfSales.SelectMany(d => d.Discounts).Distinct().Skip(skip).Take(take);

            return closestDiscounts.AsQueryable();
        }
    }
}