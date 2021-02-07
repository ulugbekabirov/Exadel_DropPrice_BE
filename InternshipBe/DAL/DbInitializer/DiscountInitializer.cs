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
            AddDiscount(2, "Акция Супер шестерка", "6 больших пицц 31 см: 4 сыра+ Ромео+ Деревенская +Пикантная +Гавайская +Народная",
                20, DateTime.Now, DateTime.Now.AddDays(100), true, null,
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Мстиславца").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Пицца" || t.Name == "Выгодно").ToList());

            AddDiscount(2, "Акция Пышное трио", "3 большие пиццы 31 см. с пышным краем: Супер Пепперони + Аппетитная + Народная", 
                10, DateTime.Now, DateTime.Now.AddDays(100), true, "7777",
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Громова" || p.Name == "Пицца темпо Бобруйская").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Уютное место" || t.Name == "Пицца").ToList());

            AddDiscount(2, "Акция ХИТ - трик тонкое тесто", "3 большие пиццы 31см :Супер Пепперони + Везувий +Чикен Барбекю+ Coca-Cola 1литр",
                30, DateTime.Now, DateTime.Now.AddDays(100), true, null,
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Громова" || p.Name == "Пицца темпо Бобруйская" || p.Name == "Пицца темпо Мстиславца").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Пицца" || t.Name == "Выгодно" || t.Name == "Уютное место").ToList());

            //KFC
            AddDiscount(3, "Баскет дуэт со скидкой 50% по купону 5050", "С 6 ферваля компанейский Баскет Дуэт – минус 50 %! В одном баскете собрали для вас: сочные кусочки курицы, острые крылышки, нежные стрипсы и картофель фри.Есть смысл прийти с другом.",
                50, DateTime.Now, DateTime.Now.AddDays(100), true, "5050",
                _context.Vendors.Find(3),
                _context.PointOfSales.Where(p => p.Name == "KFC Минск" || p.Name == "KFC Гомель" || p.Name == "KFC Ташкент" || p.Name == "KFC Warszawa" || p.Name == "KFC Walnut Creek").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Напитки" || t.Name == "Выгодно" || t.Name == "Курица" || t.Name == "Фастфуд" || t.Name == "KFC" || t.Name == "Быстро").ToList());

            AddDiscount(3, "Сандерс баскет", "Даже в плохую и холодную погоду KFC знает, как поднять тебе настроение! Целую неделю. Баскет всего за 7.70 руб.по купону 7070. Акция действует во всех ресторанах KFC Беларуси. Оформить заказ можно навынос, через окно Драйва или экспресс - окно. Ждем вас!",
                50, DateTime.Now, DateTime.Now.AddDays(100), true, "7070",
                _context.Vendors.Find(3),
                _context.PointOfSales.Where(p => p.Name == "KFC Минск" || p.Name == "KFC Гомель" || p.Name == "KFC Ташкент" || p.Name == "KFC Warszawa" || p.Name == "KFC Walnut Creek").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Напитки" || t.Name == "Выгодно" || t.Name == "Курица" || t.Name == "Фастфуд" || t.Name == "KFC" || t.Name == "Быстро").ToList());

            //IKEA
            AddDiscount(3, "ГАРДЕРОБ, БЕЛЫЙ 175X58X201 СМ", "Бесплатно 10 лет гарантии. Подробнее об условиях гарантии – в гарантийной брошюре.Эту комбинацию ПАКС/КОМПЛИМЕНТ можно адаптировать в соответствии с вашими потребностями, воспользовавшись программой для проектирования гардеробов ПАКС.",
                15, DateTime.Now, DateTime.Now.AddDays(100), true, null,
                _context.Vendors.Find(3),
                _context.PointOfSales.Where(p => p.Name == "IKEA USA" || p.Name == "IKEA Warszawa" || p.Name == "IKEA Минск" || p.Name == "IKEA Ташкент" || p.Name == "IKEA Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мебель" || t.Name == "Дешево" || t.Name == "Для дома" || t.Name == "Доставка").ToList());

            AddDiscount(3, "КРЕСЛО, ШИФТЕБУ ТЕМНО-СИНИЙ", "Двусторонние подушки спинки обеспечивают мягкую опору для спины.Подушку спинки можно расположить так, как вам удобно.Бесплатно 10 лет гарантии. Подробнее об условиях гарантии – в гарантийной брошюре.Бесплатно 10 лет гарантии.",
                5, DateTime.Now, DateTime.Now.AddDays(100), true, null,
                _context.Vendors.Find(3),
                _context.PointOfSales.Where(p => p.Name == "IKEA Минск" || p.Name == "IKEA Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мебель" || t.Name == "Для дома" || t.Name == "Доставка").ToList());

            //Chanel
            AddDiscount(5, "Chanel N°5 for Women Парфюмерная вода для женщин", $"Тип аромата: Альдегидные, Цветочные{Environment.NewLine}Начальная нота: Альдегиды, Бергамот, Иланг - иланг, Нероли, Персик, Лимон{Environment.NewLine}Нота сердца: Жасмин, Ирис, Ландыш, Роза, Корень ириса",
                39, DateTime.Now, DateTime.Now.AddDays(100), true, null,
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Cravt Минск" || p.Name == "AnnaClair Минск").ToList(),
                _context.Tags.Where(t => t.Name == "Роскошь" || t.Name == "Парфюмерия" || t.Name == "Духи").ToList());

            AddDiscount(5, "Босоножки", $"Кожа ягненка; Золотистый; Арт.G36876 X55079 0K203{Environment.NewLine}высота каблука 50 mm",
                5, DateTime.Now, DateTime.Now.AddDays(100), true, null,
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "Cravt Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Роскошь" || t.Name == "Мода" || t.Name == "Обувь" || t.Name ==   "Красота").ToList());

            AddDiscount(5, "Набор Chanel Chance Perfume Pencils", $"Набор Chanel Chance Perfume Pencils из 4 парфюмерных карандашей (духи - карандаш), 4 х 1,2g{Environment.NewLine}Страна производитель: Китай",
                10, DateTime.Now, DateTime.Now.AddDays(100), true, null,
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "Cravt Гомель" || p.Name == "AnnaClair Минск" || p.Name == "Cravt Минск").ToList(),
                _context.Tags.Where(t => t.Name == "Уход за кожей" || t.Name == "Красота").ToList());

            //Chanel
            AddDiscount(5, "CHANCE EAU VIVE Туалетная вода спрей", @"Цветочный пикантный аромат в круглом флаконе. Настоящая волна энергии и ярких впечатлений. Не упустите свой незабываемый шанс. Цветочный пикантный аромат, пронизанный бодрящими нотами грейпфрута и красного апельсина.Верхние ноты дарят взрывную свежесть.В сердце аромата - нежный, женственный жасмин.Аккорды кедра и ириса раскрывают истинную элегантность композиции, оставляя за собой мягкий шлейф.",
                15, DateTime.Now, DateTime.Now.AddDays(60), true, "LION",
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "AnnaClair Минск" || p.Name == "Cravt Минск" || p.Name == "Cravt Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Парфюмерия" || t.Name == "Роскошь" || t.Name == "Красота").ToList());

            AddDiscount(5, "CHANEL CRISTALLE Парфюмерная вода", @"Живительный порыв свежего воздуха звучит как продолжение чистых линий свободной элегантности. Свежий цветочный аромат, соединяющий в себе характер и прозрачность, силу и легкость, естественность и изысканность. Свежий цветочный аромат, прозрачный и элегантный. Нежная и радостная композиция открывается порывом свежих фруктовых нот. Ее сердце расцветает зелеными нотами гиацинта, смягченными аккордом жимолости, а шлейф соткан из абсолю жасмина и флорентийского ириса.",
                17, DateTime.Now, DateTime.Now.AddDays(142), true, "ALLURE",
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "AnnaClair Минск" || p.Name == "Cravt Минск" || p.Name == "Cravt Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Парфюмерия" || t.Name == "Роскошь" || t.Name == "Красота").ToList());
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
