﻿using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<Discount> GetClosestDiscounts(int skip, int take, double latitude, double longitude)
        {
            GeoCoordinate location = new GeoCoordinate(latitude, longitude);

            var closestPointsOfSales = _context.PointOfSales
                .OrderBy(p => location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)));
            
            return _entities.Where(d => closestPointsOfSales.Select(p => p.Id).Contains(d.Id)).Skip(skip).Take(take);
        }

        public IQueryable<SavedDiscount> GetSavedDiscounts(User user)
        {
            return _context.SavedDiscounts.Where(s => s.UserId == user.Id);
        }
    }
}
