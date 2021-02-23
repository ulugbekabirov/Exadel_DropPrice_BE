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

        public void AddDiscount(int vendorId, string name, string description, int discountAmount, DateTime startDate, DateTime endDate, bool activityStatus, string promoCode, Vendor vendor, List<PointOfSale> pointOfSales, List<Tag> tags)
        {
            var discount = new Discount()
            {
                VendorId = vendorId,
                Name = name,
                Description = description,
                DiscountAmount = discountAmount,
                EndDate = endDate,
                StartDate = startDate,
                ActivityStatus = activityStatus,
                PromoCode = promoCode,
                Vendor = vendor,
                PointOfSales = pointOfSales,
                Tags = tags,
            };

            _context.Discounts.Add(discount);

            _context.SaveChanges();
        }

        public void InitializeDiscounts()
        {
            //Evos 
            AddDiscount(1, "Evos Lavash XALAPENIE", @"Тесто – лаваш, нежное куриное филе (Halal) в фирменной панировке, листья салата, перец Халапеньо, свежие помидоры, маринованные огурцы, соусы Майонез и Кетчуп",
                12, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(40), true, null,
                _context.Vendors.Find(1),
                _context.PointOfSales.Where(p => p.Name == "Evos Lavash Center М.Юсуфа" || p.Name == "Evos Lavash Center А.Дониша" || p.Name == "Evos Lavash Center Мукими").ToList(),
                _context.Tags.Where(t => t.Name == "Вкусно" || t.Name == "Еда навынос" || t.Name == "Доставка" || t.Name == "Дешево" || t.Name == "Фастфуд").ToList());

            AddDiscount(1, "Evos WINGS/9PC", @"Хрустящие куриные крылышки (Halal) в фирменной панировке",
               12, DateTime.Now, DateTime.Now.AddDays(40), true, null,
               _context.Vendors.Find(1),
               _context.PointOfSales.Where(p => p.Name == "Evos Lavash Center М.Юсуфа" || p.Name == "Evos Lavash Center А.Дониша" || p.Name == "Evos Lavash Center Мукими").ToList(),
               _context.Tags.Where(t => t.Name == "Вкусно" || t.Name == "Еда навынос" || t.Name == "Доставка" || t.Name == "Дешево" || t.Name == "Фастфуд").ToList());

            //Pizza
            AddDiscount(2, "Акция Супер шестерка", "6 больших пицц 31 см: 4 сыра+ Ромео+ Деревенская +Пикантная +Гавайская +Народная",
                20, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(170), true, "1111",
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Мстиславца").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Пицца" || t.Name == "Выгодно").ToList());

            AddDiscount(2, "Акция Пышное трио", "3 большие пиццы 31 см. с пышным краем: Супер Пепперони + Аппетитная + Народная",
                10, DateTime.Now, DateTime.Now.AddDays(140), true, "7777",
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Громова" || p.Name == "Пицца темпо Бобруйская").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Уютное место" || t.Name == "Пицца").ToList());

            AddDiscount(2, "Акция ХИТ - трик тонкое тесто", "3 большие пиццы 31см :Супер Пепперони + Везувий +Чикен Барбекю+ Coca-Cola 1литр",
                30, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(150), true, "7773",
                _context.Vendors.Find(2),
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Громова" || p.Name == "Пицца темпо Бобруйская" || p.Name == "Пицца темпо Мстиславца").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Пицца" || t.Name == "Выгодно" || t.Name == "Уютное место").ToList());

            //KFC
            AddDiscount(3, "Баскет дуэт со скидкой 50% по купону 5050", "С 6 ферваля компанейский Баскет Дуэт – минус 50 %! В одном баскете собрали для вас: сочные кусочки курицы, острые крылышки, нежные стрипсы и картофель фри.Есть смысл прийти с другом.",
                50, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(200), true, "5050",
                _context.Vendors.Find(3),
                _context.PointOfSales.Where(p => p.Name == "KFC Минск" || p.Name == "KFC Гомель" || p.Name == "KFC Ташкент").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Напитки" || t.Name == "Выгодно" || t.Name == "Курица" || t.Name == "Фастфуд" || t.Name == "KFC" || t.Name == "Быстро").ToList());

            AddDiscount(3, "Сандерс баскет", "Даже в плохую и холодную погоду KFC знает, как поднять тебе настроение! Целую неделю. Баскет всего за 7.70 руб.по купону 7070. Акция действует во всех ресторанах KFC Беларуси. Оформить заказ можно навынос, через окно Драйва или экспресс - окно. Ждем вас!",
                50, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(190), true, "7070",
                _context.Vendors.Find(3),
                _context.PointOfSales.Where(p => p.Name == "KFC Минск" || p.Name == "KFC Гомель" || p.Name == "KFC Ташкент").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Напитки" || t.Name == "Выгодно" || t.Name == "Курица" || t.Name == "Фастфуд" || t.Name == "KFC" || t.Name == "Быстро").ToList());

            AddDiscount(3, "Шефбургер", "Шефбургера Де Люкс со скидкой 50%! И острый, и оригинальный – ждут тебя! А мы ждем вас в наших ресторанах!",
                50, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(30), true, "1717",
                _context.Vendors.Find(3),
                _context.PointOfSales.Where(p => p.Name == "KFC Минск" || p.Name == "KFC Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Доставка" || t.Name == "Напитки" || t.Name == "Выгодно" || t.Name == "Курица" || t.Name == "Фастфуд" || t.Name == "KFC" || t.Name == "Быстро").ToList());

            //IKEA
            AddDiscount(4, "ГАРДЕРОБ, БЕЛЫЙ 175X58X201 СМ", "Бесплатно 10 лет гарантии. Подробнее об условиях гарантии – в гарантийной брошюре.Эту комбинацию ПАКС/КОМПЛИМЕНТ можно адаптировать в соответствии с вашими потребностями, воспользовавшись программой для проектирования гардеробов ПАКС.",
                15, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(260), true, null,
                _context.Vendors.Find(4),
                _context.PointOfSales.Where(p => p.Name == "IKEA USA" || p.Name == "IKEA Минск" || p.Name == "IKEA Ташкент" || p.Name == "IKEA Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мебель" || t.Name == "Дешево" || t.Name == "Для дома" || t.Name == "Доставка").ToList());

            AddDiscount(4, "КРЕСЛО, ШИФТЕБУ ТЕМНО-СИНИЙ", "Двусторонние подушки спинки обеспечивают мягкую опору для спины.Подушку спинки можно расположить так, как вам удобно.Бесплатно 10 лет гарантии. Подробнее об условиях гарантии – в гарантийной брошюре.Бесплатно 10 лет гарантии.",
                5, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(356), true, null,
                _context.Vendors.Find(4),
                _context.PointOfSales.Where(p => p.Name == "IKEA Минск" || p.Name == "IKEA Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мебель" || t.Name == "Для дома" || t.Name == "Доставка").ToList());

            AddDiscount(4, "СВЕТИЛЬНИК НА СОЛНЕЧНОЙ БАТАРЕЕ", "Легко использовать, так как провода и розетки не нужны.Батарея трансформирует солнечный свет в электроэнергию: никаких затрат на электричество и забота об экологии.",
                29, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(40), true, null,
                _context.Vendors.Find(4),
                _context.PointOfSales.Where(p => p.Name == "IKEA Минск").ToList(),
                _context.Tags.Where(t => t.Name == "Светильник" || t.Name == "Для дома" || t.Name == "Доставка").ToList());

            //Chanel
            AddDiscount(5, "Chanel N°5 for Women Парфюмерная вода для женщин", $"Тип аромата: Альдегидные, Цветочные{Environment.NewLine}Начальная нота: Альдегиды, Бергамот, Иланг - иланг, Нероли, Персик, Лимон{Environment.NewLine}Нота сердца: Жасмин, Ирис, Ландыш, Роза, Корень ириса",
                39, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(95), true, "FRAICHE",
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Cravt Минск" || p.Name == "AnnaClair Минск").ToList(),
                _context.Tags.Where(t => t.Name == "Роскошь" || t.Name == "Парфюмерия" || t.Name == "Духи").ToList());

            AddDiscount(5, "Босоножки", $"Кожа ягненка; Золотистый; Арт.G36876 X55079 0K203{Environment.NewLine}высота каблука 50 mm",
                5, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(80), true, "TENDRE",
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "Cravt Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Роскошь" || t.Name == "Мода" || t.Name == "Обувь" || t.Name == "Красота").ToList());

            AddDiscount(5, "Набор Chanel Chance Perfume Pencils", $"Набор Chanel Chance Perfume Pencils из 4 парфюмерных карандашей (духи - карандаш), 4 х 1,2g{Environment.NewLine}Страна производитель: Китай",
                10, DateTime.Now, DateTime.Now.AddDays(120), true, null,
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "Cravt Гомель" || p.Name == "AnnaClair Минск" || p.Name == "Cravt Минск").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Уход за кожей" || t.Name == "Красота" || t.Name == "Макияж").ToList());

            AddDiscount(5, "CHANCE EAU VIVE Туалетная вода спрей", @"Цветочный пикантный аромат в круглом флаконе. Настоящая волна энергии и ярких впечатлений. Не упустите свой незабываемый шанс. Цветочный пикантный аромат, пронизанный бодрящими нотами грейпфрута и красного апельсина.Верхние ноты дарят взрывную свежесть.В сердце аромата - нежный, женственный жасмин.Аккорды кедра и ириса раскрывают истинную элегантность композиции, оставляя за собой мягкий шлейф.",
                15, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(60), true, "LION",
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "AnnaClair Минск" || p.Name == "Cravt Минск" || p.Name == "Cravt Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Парфюмерия" || t.Name == "Роскошь" || t.Name == "Красота").ToList());

            AddDiscount(5, "CHANEL CRISTALLE Парфюмерная вода", @"Живительный порыв свежего воздуха звучит как продолжение чистых линий свободной элегантности. Свежий цветочный аромат, соединяющий в себе характер и прозрачность, силу и легкость, естественность и изысканность. Свежий цветочный аромат, прозрачный и элегантный. Нежная и радостная композиция открывается порывом свежих фруктовых нот. Ее сердце расцветает зелеными нотами гиацинта, смягченными аккордом жимолости, а шлейф соткан из абсолю жасмина и флорентийского ириса.",
                17, DateTime.Now, DateTime.Now.AddDays(140), true, "ALLURE",
                _context.Vendors.Find(5),
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "AnnaClair Минск" || p.Name == "Cravt Минск" || p.Name == "Cravt Гомель").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Парфюмерия" || t.Name == "Роскошь" || t.Name == "Красота").ToList());

            //L'Oreal
            AddDiscount(6, "L'Oreal Paris Dermo Expertise", @"Набор косметии для лица с успокаивающим, восстанавливающим и антивозрастным эффектом уода. пододит для снятия маияжа илифтинга.",
                20, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(140), true, "JEUNESSE",
                _context.Vendors.Find(6),
                _context.PointOfSales.Where(p => p.Name == "Магазин косметики в Минске на Боровой" || p.Name == "УП Дипмаркет" || p.Name == "Магазин профессиональной косметики Cosmopro.by" || p.Name == "L'Oreal Poland Sp. zoo").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Уход за кожей" || t.Name == "Роскошь" || t.Name == "Красота").ToList());

            AddDiscount(6, "Крем после бритья L'Oreal Paris Men Expert", @"Даже мужская кожа нуждается в заботе и уходе, поэтому L'Oreal предоставляет крем после бритья с успокаивающим и увлажнающим эффектом уода.",
                23, DateTime.Now, DateTime.Now.AddDays(140), true, "FORCE",
                _context.Vendors.Find(6),
                _context.PointOfSales.Where(p => p.Name == "Магазин косметики в Минске на Боровой" || p.Name == "УП Дипмаркет" || p.Name == "L'Oreal Poland Sp. zoo").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Уход за кожей" || t.Name == "Роскошь" || t.Name == "Красота").ToList());

            AddDiscount(6, "Тинт для губ L'Oreal Paris Rouge Signature", @"L’Oréal Paris презентует первую ультрапигментированную суперстойкую помаду-тинт для губ Rouge Signature, которая дает глубокий цвет и бархатистый матовый финиш на целый день, обладая при этом невесомой текстурой. Ее нежная увлажняющая формула не дает эффекта липкой пленки и абсолютно не ощущается на губах: не сушит и не стягивает кожу. Удобный спонж-аппликатор в форме капли обеспечивает комфортное, аккуратное и суперточное нанесение по контуру.",
                18, DateTime.Now, DateTime.Now.AddDays(140), true, "UNICITE",
                _context.Vendors.Find(6),
                _context.PointOfSales.Where(p => p.Name == "Магазин косметики в Минске на Боровой" || p.Name == "УП Дипмаркет" || p.Name == "L'Oreal Poland Sp. zoo").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Роскошь" || t.Name == "Красота").ToList());

            AddDiscount(6, "Тушь для ресниц L'Oreal Paris Telescopic", @"Роскошные, удлиненные до +60% и идеально разделенные ресницы? Это возможно благодаря туши для ресниц Telescopic - первой удлиняющей туши от L'Oreal Paris с гибкой пластиковой Щеточкой-Расческой, которая разделяет каждую ресничку, обеспечивая идеальный результат. Великолепная формула придает ресницам телескопическое удлинение!",
                32, DateTime.Now, DateTime.Now.AddDays(140), true, "IDEE",
                _context.Vendors.Find(6),
                _context.PointOfSales.Where(p => p.Name == "Магазин косметики в Минске на Боровой" || p.Name == "УП Дипмаркет" || p.Name == "Магазин профессиональной косметики Cosmopro.by" || p.Name == "L'Oreal Poland Sp. zoo").ToList(),
                _context.Tags.Where(t => t.Name == "Мода" || t.Name == "Роскошь" || t.Name == "Красота").ToList());

            //Belwest
            AddDiscount(7, "Сумка женская 9С4248К45 ЧЕРН", @"Черная женская сумка из искусственнойкожи. Идеально подойдёт к любому наряду",
                25, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(30), true, null,
                _context.Vendors.Find(7),
                _context.PointOfSales.Where(p => p.Name == "Belwest ТЦ Столица" || p.Name == "Belwest Минск" || p.Name == "Belwest ТД Неман" || p.Name == "BELWEST Витебск" || p.Name == "Belwest ТК Корона").ToList(),
                _context.Tags.Where(t => t.Name == "Одежда" || t.Name == "Красота" || t.Name == "Роскошь").ToList());

            AddDiscount(7, "Сумка женская 0С2548К45 БОРДО", @"Прекрасная женская сумка из натуральной кожи цвета борда. Идеально подчеркнёт ваш стиль и красоту.",
                12, DateTime.Now, DateTime.Now.AddDays(30), true, null,
                _context.Vendors.Find(7),
                _context.PointOfSales.Where(p => p.Name == "Belwest ТЦ Столица" || p.Name == "Belwest ТД Неман" || p.Name == "BELWEST Витебск" || p.Name == "Belwest ТК Корона").ToList(),
                _context.Tags.Where(t => t.Name == "Одежда" || t.Name == "Красота" || t.Name == "Роскошь").ToList());

            AddDiscount(7, "Сапоги женские 2132076", @"Женская зимняя обувь из натуральной кожи, текстиля и полиуретана.",
                10, DateTime.Now, DateTime.Now.AddDays(30), true, null,
                _context.Vendors.Find(7),
                _context.PointOfSales.Where(p => p.Name == "Belwest ТЦ Столица" || p.Name == "Belwest Минск" || p.Name == "Belwest ТД Неман" || p.Name == "BELWEST Витебск" || p.Name == "Belwest ТК Корона").ToList(),
                _context.Tags.Where(t => t.Name == "Одежда" || t.Name == "Красота" || t.Name == "Обувь" || t.Name == "Роскошь").ToList());

            AddDiscount(7, "Ботинки женские 2132220", @"Демисезонные женские ботинки, хорошо подойдутк вашему осеннему наряду.",
                32, DateTime.Now, DateTime.Now.AddDays(30), true, null,
                _context.Vendors.Find(7),
                _context.PointOfSales.Where(p => p.Name == "Belwest Минск" || p.Name == "Belwest ТД Неман" || p.Name == "BELWEST Витебск" || p.Name == "Belwest ТК Корона").ToList(),
                _context.Tags.Where(t => t.Name == "Одежда" || t.Name == "Красота" || t.Name == "Обувь").ToList());

            //adidas
            AddDiscount(8, "Adidas Кроссовки STRUTTER", @"Кроссовки выполнены из сочетания натуральной кожи и искусственной кожи. Легкая стелька Adibouncy из ЭВА. Детали: регулируемая застежка на шнуровку, внутренняя подкладка из текстиля, резиновая подошва. ",
                25, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(80), true, null,
                _context.Vendors.Find(8),
                _context.PointOfSales.Where(p => p.Name == " Adidas Гродно " || p.Name == "Футбольный магазин soccershop.by " || p.Name == " Adidas Минск").ToList(),
                _context.Tags.Where(t => t.Name == "Бег" || t.Name == "Обувь" || t.Name == "Тренировка" || t.Name == "Спорт").ToList());

            AddDiscount(8, "ШОРТЫ ДЛЯ ФИТНЕСА ADIDAS BY STELLA MCCARTNEY", @"Ты не приходишь в спортзал просто так. И какой бы ни была причина, поблагодари себя за заботу. А затем надень эти шорты от Стеллы Маккартни и задай себе жару. Они отлично подойдут для интенсивных тренировок. Впитывающая влагу ткань сохраняет приятное ощущение сухости с первой до последней минуты. ",
                12, DateTime.Now, DateTime.Now.AddDays(80), true, null,
                _context.Vendors.Find(8),
                _context.PointOfSales.Where(p => p.Name == " Adidas Гродно " || p.Name == "Футбольный магазин soccershop.by " || p.Name == " Adidas Минск" || p.Name == "Adidas Ташкент").ToList(),
                _context.Tags.Where(t => t.Name == "Бег" || t.Name == "Тренировка" || t.Name == "Спорт" || t.Name == "Оджда").ToList());

            AddDiscount(8, "ФУТБОЛКА ДЛЯ ФИТНЕСА FREELIFT", @"Базовая футболка для фитнеса — основа любого спортивного гардероба. У этой модели очень лаконичный дизайн, так что ее легко сочетать с чем угодно. Ткань впитывает влагу и приятно ощущается на коже. Благодаря классическому крою она выглядит как обычная футболка на каждый день.",
                10, DateTime.Now, DateTime.Now.AddDays(80), true, null,
                _context.Vendors.Find(8),
                _context.PointOfSales.Where(p => p.Name == " Adidas Гродно " || p.Name == " Adidas Минск" || p.Name == "Adidas Ташкент").ToList(),
                _context.Tags.Where(t => t.Name == "Бег" || t.Name == "Тренировка" || t.Name == "Спорт" || t.Name == "Оджда").ToList());

            AddDiscount(8, "Adidas Кроссовки RETRORUNNER", @"Кроссовки выполнены из текстиля с накладками из натуральной замши. Мягкая подкладка для исключительного комфорта. Плоские шнурки уменьшают давление над подъемом и обеспечивают стабильную и удобную посадку ",
                20, DateTime.Now, DateTime.Now.AddDays(80), true, null,
                _context.Vendors.Find(8),
                _context.PointOfSales.Where(p => p.Name == " Adidas Гродно " || p.Name == "Футбольный магазин soccershop.by " || p.Name == " Adidas Минск" || p.Name == "Adidas Ташкент").ToList(),
                _context.Tags.Where(t => t.Name == "Бег" || t.Name == "Обувь" || t.Name == "Тренировка" || t.Name == "Спорт").ToList());

            //VitrA
            AddDiscount(9, "Vitra Table Solvay", @"Прекрасный стол для вашей гостинной или зала. При заказе вы сможете подобрать пододящий размер.",
                24, DateTime.Now, DateTime.Now.AddDays(40), true, null,
                _context.Vendors.Find(9),
                _context.PointOfSales.Where(p => p.Name == "Гемма - строительный магазин" || p.Name == "Магазин Santehlux" || p.Name == "VitrA Home salon firmowy Bartycka 24 paw.228" || p.Name == "VitrA Узбекистан").ToList(),
                _context.Tags.Where(t => t.Name == "Мебель" || t.Name == "Красота" || t.Name == "Для дома" || t.Name == "Уют").ToList());

            AddDiscount(9, "Fauteuil de Salon Armchair", @"Fauteuil de Salon объединяет простые плоскости в единый архитектурный объект с удобной поверхностью сиденья и спинкой. Ощутите комфорт и уют, купите кресло Fauteuil de Salon",
                32, DateTime.Now, DateTime.Now.AddDays(40), true, null,
                _context.Vendors.Find(9),
                _context.PointOfSales.Where(p => p.Name == "Гемма - строительный магазин" || p.Name == "Магазин Santehlux" || p.Name == "VitrA Home salon firmowy Bartycka 24 paw.228" || p.Name == "VitrA Узбекистан").ToList(),
                _context.Tags.Where(t => t.Name == "Мебель" || t.Name == "Красота" || t.Name == "Для дома" || t.Name == "Уют").ToList());

            AddDiscount(9, "Душевой гарнитур Vitra Lite LC (A45700EXP)", @"Настенный душевой гарнитур хромового цвета. Униерсален и пододит под любую ванну.",
                9, DateTime.Now, DateTime.Now.AddDays(40), true, null,
                _context.Vendors.Find(9),
                _context.PointOfSales.Where(p => p.Name == "Гемма - строительный магазин" || p.Name == "VitrA Узбекистан").ToList(),
                _context.Tags.Where(t => t.Name == "Сантехника" || t.Name == "Красота" || t.Name == "Для дома" || t.Name == "Уют").ToList());

            //Bosch
            AddDiscount(10, "Газонокосилка DLM462Z (DLM 462 Z) MAKITA", @"Аккумуляторная газонокосилка Makita DLM462Z – это самоходная модель, весом 38 кг питается от двух аккумуляторов с суммарным напряжением 36 В.",
                24, DateTime.Now, DateTime.Now.AddDays(32), true, "MAKITA",
                _context.Vendors.Find(10),
                _context.PointOfSales.Where(p => p.Name == "Сервисный центр ИП \"Роберт Бош\"" || p.Name == "MAJSTER BOSCH" || p.Name == "Bosch Hrodna" || p.Name == "Magazin Bosh").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Для дома" || t.Name == "Уют").ToList());

            AddDiscount(10, "Пылесос UniversalVac 18 BOSCH (06033B9103)", @"Аккумуляторный ручной пылесос Bosch UniversalVac 18 - мобильное, легкое и мощное устройство с постоянной силой всасывания. Удобен при уборке автомобилей, очистке ковровых покрытий и полов.",
                33, DateTime.Now, DateTime.Now.AddDays(32), true, null,
                _context.Vendors.Find(10),
                _context.PointOfSales.Where(p => p.Name == "Сервисный центр ИП \"Роберт Бош\"" || p.Name == "MAJSTER BOSCH" || p.Name == "Bosch Hrodna" || p.Name == "Magazin Bosh").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Для дома" || t.Name == "Уют").ToList());

            AddDiscount(10, "Дрель-шуруповерт DHP485SYE (DHP 485 SYE) MAKITA", @"Ударная дрель-шуруповерт Makita DHP485SYE – компактное отличающееся эффективностью устройство. Используется оно для создания отверстий и для работ с элементами крепежа. Благодаря тому, что функционирование предлагаемой техники не зависит от сети, ее можно применять в самых разных местах.",
                10, DateTime.Now, DateTime.Now.AddDays(32), true, "MAKITA",
                _context.Vendors.Find(10),
                _context.PointOfSales.Where(p => p.Name == "Сервисный центр ИП \"Роберт Бош\"" || p.Name == "MAJSTER BOSCH" || p.Name == "Bosch Hrodna" || p.Name == "Magazin Bosh").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Дорого" || t.Name == "Для дома").ToList());

            //Electrolux
            AddDiscount(11, "Варочная панель Electrolux EHF96140FK", @"Быть может она и попроще, чем другие модели электролюкса. Но от этого не менее удобная и функциональная. Управление хоть и механическое, но очень точное и комфортное в использовании. Моется плита замечательно, есть функция мгновенного нагрева.",
                24, DateTime.Now, DateTime.Now.AddDays(32), true, "2592",
                _context.Vendors.Find(11),
                _context.PointOfSales.Where(p => p.Name == "Electrolux Ташкент" || p.Name == "Электросила Минск" || p.Name == "Электросила Гродно").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Уют" || t.Name == "Для дома").ToList());

            AddDiscount(11, "Духовой шкаф Electrolux EZB52410AW", @"Наша конвекционная печь 300 нагревается быстрее, чем обычная печь. Вентилятор распределяет тепло по всей полости, а значит, ваша еда готовится быстро и равномерно. Теперь вы можете испечь совершенно однородное печенье без необходимости переворачивать его на полпути.",
                20, DateTime.Now, DateTime.Now.AddDays(32), true, "9302",
                _context.Vendors.Find(11),
                _context.PointOfSales.Where(p => p.Name == "Electrolux Ташкент" || p.Name == "Электросила Минск" || p.Name == "Электросила Гродно").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Уют" || t.Name == "Для дома" || t.Name == "Комфорт").ToList());

            AddDiscount(11, "Пылесос Electrolux EC41-H2SW", @"Отличный пылесос для вашего дома. Не создаёт лишнегошума и не оставляет грязи. Идеальный выбор для чистого дома.",
                15, DateTime.Now, DateTime.Now.AddDays(32), true, "1068279",
                _context.Vendors.Find(11),
                _context.PointOfSales.Where(p => p.Name == "Electrolux Ташкент" || p.Name == "Электросила Минск" || p.Name == "Электросила Гродно").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Уют" || t.Name == "Для дома").ToList());

            AddDiscount(11, "Тепловентилятор Electrolux EFH/C-5120", @"Удобен в использовании, компактен и эффективен. Зачем ждать отоплени - согрейте себя сами!",
                25, DateTime.Now, DateTime.Now.AddDays(32), true, "0135696",
                _context.Vendors.Find(11),
                _context.PointOfSales.Where(p => p.Name == "Electrolux Ташкент" || p.Name == "Электросила Минск" || p.Name == "Электросила Гродно").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Уют" || t.Name == "Для дома" || t.Name == "Комфорт").ToList());

            AddDiscount(11, "Вентилятор Electrolux EFF-1004i", @"Отличный вентилятор за свои деньги. Тихий и удобный, с отличным дизайном. Станет спасением в жаркую погоду и орошо впишется в дизайн дома.",
                30, DateTime.Now, DateTime.Now.AddDays(32), true, "1279349",
                _context.Vendors.Find(11),
                _context.PointOfSales.Where(p => p.Name == "Electrolux Ташкент" || p.Name == "Электросила Минск" || p.Name == "Электросила Гродно").ToList(),
                _context.Tags.Where(t => t.Name == "Электротехника" || t.Name == "Уют" || t.Name == "Для дома" || t.Name == "Комфорт").ToList());

        }
    }
}
