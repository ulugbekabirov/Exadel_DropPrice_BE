using DAL.DataContext;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DbInitializer
{
    public class VendorInitializer
    {
        private readonly ApplicationDbContext _context;

        public VendorInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddVendor(string name, string description, string email, string address, string phone, string socialLinks, List<PointOfSale> pointOfSales)
        {
            _context.Vendors.Add(new Vendor()
            {
                Name = name,
                Description = description,
                Email = email,
                Address = address,
                Phone = phone,
                SocialLinks = socialLinks,
                PointOfSales = pointOfSales,
            });

            _context.SaveChanges();
        }

        public void InitializeVendors()
        {
            AddVendor("Evos Lavash Center", @"Если Вам нужны кафе Evos в Ташкенте, здесь есть то, что Вы ищете! Справочный каталог с информацией о фастфудах Evos в Ташкенте: телефоны, адреса, местонахождения на карте Ташкента с режимами работы, ссылками на их соц. сети и кратким описанием – всё это Вы можете найти на страницах нашего сайта. Сеть Evos ждет Вас, чтобы предложить свои блюда. Полный список, удобный поиск, актуальная информация о сети кафе Evos в Ташкенте в Узбекистане",
                "vendorexadel@gmail.com", @"Мирзо-Улугбекский ул.МУХАММАДА ЮСУФА, 1А", "+998 71 2031212", "{\"instagram\": \"https://www.instagram.com/evosuzbekistan/ \", \"facebook\": \"https://www.facebook.com/evosuzbekistan/ \", \"webSite\" : \"https://evos.uz/ \"} ",
                _context.PointOfSales.Where(p => p.Name == "Evos Lavash Center М.Юсуфа" || p.Name == "Evos Lavash Center А.Дониша" || p.Name == "Evos Lavash Center Мукими").ToList());
            
            AddVendor("Пицца Темпо", @"Пицца Темпо – крупнейшая сеть пиццерий в Республике Беларусь: 20 уютных пиццерий расположились в городе Минске, Гродно, Могилеве и Молодечно более 1 500 000 пицц ежегодно радуют наших Гостей в залах пиццерий и с доставкой", 
                "vendorexadel@gmail.com", "г.Минск, пр-т Победителей 89, комн.", "+375 (017) 375-77-73", "{\"instagram\": \"https://www.instagram.com/pizzatempo/ \", \"facebook\": \"https://www.facebook.com/pizzatempo.by?fref=ts \", \"webSite\" : \"https://www.pizzatempo.by/ \"} ",
                _context.PointOfSales.Where(p => p.Name == "Пицца темпо Громова" || p.Name == "Пицца темпо Бобруйская" || p.Name == "Пицца темпо Мстиславца").ToList());
            
            AddVendor("KFC", @"Kentucky Fried Chicken, сокращённо KFC — международная сеть ресторанов общественного питания, специализирующаяся на блюдах из курицы. Штаб-квартира компании располагается в городе Луисвилле в штате Кентукки. KFC — вторая по торговому обороту сеть кафе в мире, уступающая лишь компании McDonald's.",
                "vendorexadel@gmail.com", "Луисвилл, Кентукки, США", "+375296470730", "{\"instagram\": \"https://www.instagram.com/kfc/ \", \"facebook\": \"https://www.facebook.com/KFC/ \", \"webSite\" : \"https://www.kfc.com/menu \"} ",
                 _context.PointOfSales.Where(p => p.Name == "KFC Минск" || p.Name == "KFC Гомель" || p.Name == "KFC Ташкент" || p.Name == "KFC Warszawa" || p.Name == "KFC Walnut Creek").ToList());
            
            AddVendor("IKEA", @"IKEA — основанная в Швеции нидерландская производственно - торговая группа компаний, владелец одной из крупнейших в мире торговых сетей по продаже мебели и товаров для дома.",
                 "vendorexadel@gmail.com", "Olof Palmestraat 1, 2616 LN Delft, Нидерланды", "+31503168772", "{\"instagram\": \"https://www.instagram.com/ikeausa/ \", \"facebook\": \"https://www.facebook.com/IKEAUSA/ \", \"webSite\" : \"https://www.ikea.com/ \"} ",
                 _context.PointOfSales.Where(p => p.Name == "IKEA USA" || p.Name == "IKEA Warszawa" || p.Name == "IKEA Минск" || p.Name == "IKEA Ташкент" || p.Name == "IKEA Гомель").ToList());
            
            AddVendor("Chanel", @"Chanel is a French fashion house that focuses on women's high fashion and ready-to-wear clothes, luxury goods and accessories. The company is owned by Alain Wertheimer and Gérard Wertheimer, grandsons of Pierre Wertheimer, who was an early business partner of the couturière Coco Chanel.",
                "vendorexadel@gmail.com", "France, Paris, Neuilly-sur-Seine 135 Avenue Charles de Gaulle", "+33 1 42 60 58 58", "{\"instagram\": \"https://www.instagram.com/chanelofficial/ \", \"facebook\": \"https://www.facebook.com/chanel/ \", \"webSite\" : \"https://www.chanel.com/us/ \"} ",
                _context.PointOfSales.Where(p => p.Name == "Chanel Boutique Ташкент" || p.Name == "AnnaClair Минск" || p.Name == "Cravt Минск" || p.Name == "Cravt Гомель").ToList());
            
            AddVendor("L’Oreal", @"L`Oreal Paris (Лореаль) - один из ведущих косметических брендов мира, мы предлагаем вам профессиональные косметические средства для тела, лица и волос",
                "vendorexadel@gmail.com", @"4-6 Rue Bertrand Sincholle, 92110 Clichy, Франция", "+7 (495) 258 31 91", "{\"instagram\": \"https://www.instagram.com/lorealparis/ \", \"facebook\": \"https://www.facebook.com/loreal \", \"webSite\" : \"https://loreal-paris.ru \"} ",
                _context.PointOfSales.Where(p => p.Name == "Магазин косметики в Минске на Боровой" || p.Name == "УП Дипмаркет" || p.Name == "Магазин профессиональной косметики Cosmopro.by" || p.Name == "L'Oreal Poland Sp. zoo").ToList());
            
            AddVendor("Belwest", @" Belwest - этомультибрендовая торговая сеть, представляющая мужскую, женскую, детскую обувь и аксессуары из натуральной кожи. В интернет-магазине belwest.by представлен широкий ассортимент высококачественной обуви разного стиля и сезона. ",
                "vendorexadel@gmail.com", @" Беларусь, 210026 г. Витебск, пр-т Генерала Людникова, 10", "+375(29) 899 11 88", "{\"instagram\": \"https://www.instagram.com/adidas/?hl=ru \", \"facebook\": \"https://www.facebook.com/belwest.shoes \", \"webSite\" : \"https://belwest.by/ru \"} ",
                _context.PointOfSales.Where(p => p.Name == "Belwest ТЦ Столица" || p.Name == "Belwest Минск" || p.Name == "Belwest ТД Неман" || p.Name == "BELWEST Витебск" || p.Name == "Belwest ТК Корона").ToList());
            
            AddVendor("Adidas", @" Adidas - крупнейший бренд, создающий одежду и обувь для занятий спортом с использованием передовых технологий. Это коллекции, которые помогают добиваться максимальных результатов в любом виде спорта как начинающим, так и профессиональным атлетам.",
                "vendorexadel@gmail.com", @"220121, Беларусь, г. Минск, ул. Глебки, д.2, офис 13а", "+375(29) 2 495 495", "{\"instagram\": \"https://www.instagram.com/lorealparis/ \", \"facebook\": \"https://www.facebook.com/adidas \", \"webSite\" : \"https://www.adidas.ru \"} ",
                _context.PointOfSales.Where(p => p.Name == "Adidas Гродно" || p.Name == "Футбольный магазин soccershop.by" || p.Name == "Adidas Минск" || p.Name == "Adidas Ташкент").ToList());
            
            AddVendor("Vitra", @" Компания Vitra специализируется на производстве сантехники, керамической плитки и керамогранита. У ней вы сможете приобрести все необходимые товары для вашего дома",
                "vendorexadel@gmail.com", @"Vitra International AG, a Swiss corporation Klünenfeldstrasse 22 4127 Birsfelden Switzerland", "+41 61 377 00 00", "{\"instagram\": \"https://www.instagram.com/vitra \", \"facebook\": \"https://www.facebook.com/vitra \", \"webSite\" : \"https://www.vitra.com/en-un/home \"} ",
                _context.PointOfSales.Where(p => p.Name == "Гемма - строительный магазин" || p.Name == "Магазин Santehlux" || p.Name == "VitrA Home salon firmowy Bartycka 24 paw.228" || p.Name == "VitrA Узбекистан").ToList());

            AddVendor("Bosch", @"Bosch - сделано для жизни. Мы хотим, чтобы наша продукция вызывала энтузиазм, улучшала качество жизни и помогала сохранить природные ресурсы.",
                "vendorexadel@gmail.com", @"Auf der Breit 4, 76227 Karlsruhe, Германия", "+49 711 40040990", "{\"instagram\": \"https://www.instagram.com/boschglobal\", \"facebook\": \"https://www.facebook.com/BoschGlobal\", \"webSite\" : \"http://www.bosch.com/\"} ",
                _context.PointOfSales.Where(p => p.Name == "Сервисный центр ИП \"Роберт Бош\"" || p.Name == "MAJSTER BOSCH" || p.Name == "Bosch Hrodna" || p.Name == "Magazin Bosh").ToList());

            AddVendor("Electrolux", @"Опираясь на наши шведские ценности и прочную связь с природой, мы создаем продукты с очевидной целью. Мы делаем все, что можем, чтобы заботиться о здоровье нашей планеты ради будущих поколений.",
                "vendorexadel@gmail.com", @"Götgatan 58, 118 26 Stockholm, Швеция", "+7 495 248 44 44", "{\"instagram\": \"https://www.instagram.com/electrolux/\", \"facebook\": \"https://www.facebook.com/Electrolux\", \"webSite\" : \"https://www.electrolux.ru\"} ",
                _context.PointOfSales.Where(p => p.Name == "Electrolux Ташкент" || p.Name == "Электросила Минск" || p.Name == "Электросила Гродно").ToList());

            AddVendor("Stanley", @"Since 1843 STANLEY® tools have been on the belt and in the hands of professional contractors and accomplished homeowners. Synonymous with quality, reliability, innovation, and value, STANLEY is the first name in tape measures and trusted worldwide for accuracy and dependability. We’re proud of our reputation for excellence and dedicated to continually testing, designing and improving our products to ensure quality and maximum function. Maintaining our standing as the world's best at what we do is vital to us and what you expect from a name like STANLEY. For more than 175 years our innovative products have helped build, repair and protect our world. Today that legacy continues. Explore our history by using the interactive timeline below.",
                "vendorexadel@gmail.com", @"WALNUT CREEK HARDWARE 14844S 2044 MT DIABLO BLVD WALNUT CREEK, CA 94596", "(925) 705-7500", "{\"instagram\": \"https://www.instagram.com/stanleytools/\", \"facebook\": \"https://www.facebook.com/STANLEYTools\", \"webSite\" : \"https://www.stanleytools.com/\"} ",
                _context.PointOfSales.Where(p => p.Name == "Stanley Walnut Creek").ToList());

            AddVendor("Head & Shoulders", @"Head & Shoulders — американский бренд, специализирующийся на шампунях против перхоти. Бренд Head & Shoulders был основан американской компанией Procter & Gamble в 1961 году.",
                "vendorexadel@gmail.com", "Ленинградское шоссе, 16А корп. 2, Москва, Россия, 125171", "+7 495 258-58-88", "{\"instagram\": \"https://www.instagram.com/headandshoulderseu\", \"facebook\": \"https://www.facebook.com/headandshoulders/\", \"webSite\" : \"https://www.headandshoulders.ru/ru-ru\"} ",
                 _context.PointOfSales.Where(p => p.Name == "Head & Shoulders Минск" || p.Name == "Head & Shoulders Гомель" || p.Name == "Head & Shoulders Витебск").ToList());

            AddVendor("Gillette", @"Gillette — бренд компании Procter & Gamble, производитель аксессуаров для бритья и ухода за телом. Созданный в 1901 году американским изобретателем Кингом Кэмпом Жиллеттом, фирма производит бритвенные системы, станки и лезвия к ним, аксессуары для бритья."
                "vendorexadel@gmail.com", "Ленинградское шоссе, 16А корп. 2, Москва, Россия, 125171", "+7 495 258 - 58 - 88", "{\"instagram\": \"https://www.instagram.com/gillette/\", \"facebook\": \"https://www.facebook.com/gillette\", \"webSite\" : \"https://gillette.com/\"} ",
                 _context.PointOfSales.Where(p => p.Name == "Head & Shoulders Минск" || p.Name == "Head & Shoulders Гомель" || p.Name == "Head & Shoulders Витебск").ToList());
        }
    }
}
