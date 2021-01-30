using DAL.DataContext;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DbInitializer
{
    public class DiscountInitializer
    {
        private readonly ApplicationDbContext _db;

        public DiscountInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InitializeDiscounts()
        {
            for (int i = 1; i <= 5; i++)
            {
                AddDiscount(1, $"Coffee Plus{i}", "The best coffee PLUS", i * i, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                    _db.Vendors.Find(1), 
                    _db.PointOfSales.Where(p => p.Name == "Coffee").ToList(),
                    _db.Tags.Where(t => t.Name == "Plus" || t.Name == "CoffeePlus" || t.Name == "TheBestCoffee").ToList());
            }

            for (int i = 1; i <= 5; i++)
            {
                AddDiscount(1, $"Food{i}", "The best food", i * i, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                    _db.Vendors.Find(2), 
                    _db.PointOfSales.Where(p => p.Name == "Food").ToList(),
                    _db.Tags.Where(p => p.Name == "Food").ToList());
            }

            for (int i = 1; i <= 5; i++)
            {
                AddDiscount(1, $"Reebok{i}", "The best snickers", i * i, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                    _db.Vendors.Find(3), 
                    _db.PointOfSales.Where(p => p.Name == "Reebok").ToList(),
                    _db.Tags.Where(t => t.Name == "ReeBok").ToList());
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

            _db.Discounts.Add(discount);

            _db.SaveChanges();  

            AddDiscountToVendor(vendorId, discount);

            AddDiscountToPointOfSales(pointOfSales, discount);

            AddDiscountToTags(tags, discount);

            _db.SaveChanges();
        }

        public void AddDiscountToVendor(int vendorId, Discount discount)
        {
            _db.Vendors.Find(vendorId).Discounts.Add(discount);
        }

        public void AddDiscountToPointOfSales(List<PointOfSale> pointOfSales, Discount discount)
        {
            for (int i = 0; i < pointOfSales.Count; i++)
            {
                _db.PointOfSales.Find(pointOfSales[i].Id).Discounts.Add(discount);
            }
        }

        public void AddDiscountToTags(List<Tag> tags, Discount discount)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                _db.Tags.Find(tags[i].Id).Discounts.Add(discount);
            }
        }
    }
}
