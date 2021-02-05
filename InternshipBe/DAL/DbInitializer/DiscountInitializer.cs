using DAL.DataContext;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DbInitializer
{
    public class DiscountInitializer
    {
        private readonly ApplicationDbContext _context;

        public DiscountInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeDiscounts()
        {
            for (int i = 1; i <= 5; i++)
            {
                AddDiscount(1, $"Coffee Plus{i}", "The best coffee PLUS", i * i, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                    _context.Vendors.Find(1), 
                    _context.PointOfSales.Where(p => p.Name == "Coffee").ToList(),
                    _context.Tags.Where(t => t.Name == "Coffee" || t.Name == "CoffeePlus" || t.Name == "TheBestCoffee").ToList());
            }

            for (int i = 1; i <= 5; i++)
            {
                AddDiscount(2, $"Food{i}", "The best food", i * i, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                    _context.Vendors.Find(2), 
                    _context.PointOfSales.Where(p => p.Name == "Food").ToList(),
                    _context.Tags.Where(p => p.Name == "Food").ToList());
            }

            for (int i = 1; i <= 5; i++)
            {
                AddDiscount(3, $"Reebok{i}", "The best snickers", i * i, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                    _context.Vendors.Find(3), 
                    _context.PointOfSales.Where(p => p.Name == "Reebok").ToList(),
                    _context.Tags.Where(t => t.Name == "ReeBok").ToList());
            }
        }

        public void AddDiscount(int vendorId, string name, string description, int discountAmount, DateTime startDate, DateTime endDate, bool activityStatus,
            string promoCode, Vendor vendor, List<PointOfSale> pointOfSales, List<Tag> tags)
        {
            var discount = new Discount()
            {
                Vendorid = vendorId,
                Name = name,
                Description = description,
                DiscountAmount = discountAmount,
                EndDate = endDate,
                StartDate = startDate,
                ActivityStatus = activityStatus,
                Promocode = promoCode,
                Vendor = vendor,
                PointOfSales = pointOfSales,
                Tags = tags,
            };

            _context.Discounts.Add(discount);

            AddDiscountToVendor(vendorId, discount);

            AddDiscountToPointOfSales(pointOfSales, discount);

            AddDiscountToTags(tags, discount);

            _context.SaveChanges();
        }

        public void AddDiscountToVendor(int vendorId, Discount discount)
        {
            _context.Vendors.Find(vendorId).Discounts.Add(discount);
        }

        public void AddDiscountToPointOfSales(List<PointOfSale> pointOfSales, Discount discount)
        {
            for (int i = 0; i < pointOfSales.Count; i++)
            {
                _context.PointOfSales.Find(pointOfSales[i].Id).Discounts.Add(discount);
            }
        }

        public void AddDiscountToTags(List<Tag> tags, Discount discount)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                _context.Tags.Find(tags[i].Id).Discounts.Add(discount);
            }
        }
    }
}
