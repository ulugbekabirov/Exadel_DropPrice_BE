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

        public (IQueryable<ICollection<Discount>>, Dictionary<int, double>) GetClosestDiscounts(double latitude, double longitude)
        {
            int i = 0;

            var location = new GeoCoordinate(latitude, longitude);

            var closestPointsOfSales = _context.PointOfSales.ToList()
                .Select(p => new { Id = p.Id, Discounts = p.Discounts, Distanse = location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)) })
                .OrderBy(p => p.Distanse);

            var closestDiscounts = closestPointsOfSales.Select(d => new { Id = ++i, Discounts = d.Discounts, Distance = d.Distanse });

            return (closestDiscounts.Select(d => d.Discounts).AsQueryable(), closestDiscounts.ToDictionary(k => k.Id, v => v.Distance));
        }
    }
}