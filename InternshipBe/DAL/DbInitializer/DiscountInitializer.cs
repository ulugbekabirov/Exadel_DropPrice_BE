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
            //Pizza
            AddDiscount(2, $"Акция Супер шестерка", "6 больших пицц 31 см: 4 сыра+ Ромео+ Деревенская +Пикантная +Гавайская +Народная",
                20, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Мстиславца").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Пицца" || t.Name == "Выгодно").ToList());

            AddDiscount(2, $"Акция Пышное трио", "3 большие пиццы 31 см. с пышным краем: Супер Пепперони + Аппетитная + Народная", 
                10, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, "7777",
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Громова" || p.Name == "Пицца темпо Бобруйская").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Уютное место" || t.Name == "Пицца").ToList());

            AddDiscount(2, $"Акция ХИТ - трик тонкое тесто", "3 большие пиццы 31см :Супер Пепперони + Везувий +Чикен Барбекю+ Coca-Cola 1литр",
                30, DateTime.Now, DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)), true, null,
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Громова" || p.Name == "Пицца темпо Бобруйская" || p.Name == "Пицца темпо Мстиславца").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Пицца" || t.Name == "Выгодно" || t.Name == "Уютное место").ToList());
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
