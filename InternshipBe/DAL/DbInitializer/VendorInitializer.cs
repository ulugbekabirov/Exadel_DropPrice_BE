using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class VendorInitializer
    {
        private readonly ApplicationDbContext _context;

        public VendorInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeVendors()
        {
            AddVendor("Evos Lavash Center", @"Если Вам нужны кафе Evos в Ташкенте, здесь есть то, что Вы ищете! Справочный каталог с информацией о фастфудах Evos в Ташкенте: телефоны, адреса, местонахождения на карте Ташкента с режимами работы, ссылками на их соц. сети и кратким описанием – всё это Вы можете найти на страницах нашего сайта. Сеть Evos ждет Вас, чтобы предложить свои блюда. Полный список, удобный поиск, актуальная информация о сети кафе Evos в Ташкенте в Узбекистане",
                "vendorexadel@gmail.com", @"Мирзо-Улугбекский ул.МУХАММАДА ЮСУФА, 1А", "+998 71 2031212", "{\"instagram\": \"https://www.instagram.com/evosuzbekistan/ \", \"facebook\": \"https://www.facebook.com/evosuzbekistan/ \", \"twitter\" : null, \"vk\": null, \"webSite\" : \"https://evos.uz/ \"} ");
            AddVendor("Пицца Темпо", @"Пицца Темпо – крупнейшая сеть пиццерий в Республике Беларусь: 20 уютных пиццерий расположились в городе Минске, Гродно, Могилеве и Молодечно более 1 500 000 пицц ежегодно радуют наших Гостей в залах пиццерий и с доставкой", 
                "vendorexadel@gmail.com", "г.Минск, пр-т Победителей 89, комн.", "+375 (017) 375-77-73", "{\"instagram\": \"https://www.instagram.com/pizzatempo/ \", \"facebook\": \"https://www.facebook.com/pizzatempo.by?fref=ts \", \"twitter\" : \"https://twitter.com/pizzatempo_by \", \"vk\": \"https://vk.com/tempoby \", \"webSite\" : \"https://www.pizzatempo.by/ \"} ");
            AddVendor("KFC", @"Kentucky Fried Chicken, сокращённо KFC — международная сеть ресторанов общественного питания, специализирующаяся на блюдах из курицы. Штаб-квартира компании располагается в городе Луисвилле в штате Кентукки. KFC — вторая по торговому обороту сеть кафе в мире, уступающая лишь компании McDonald's.",
                "vendorexadel@gmail.com", "Луисвилл, Кентукки, США", "+375296470730", "{\"instagram\": \"https://www.instagram.com/kfc/ \", \"facebook\": \"https://www.facebook.com/KFC/ \", \"twitter\" : \"https://twitter.com/kfc \", \"vk\": \"https://vk.com/kfcbelarusofficial \", \"webSite\" : \"https://www.kfc.com/menu \"} ");
            AddVendor("IKEA", @"IKEA — основанная в Швеции нидерландская производственно - торговая группа компаний, владелец одной из крупнейших в мире торговых сетей по продаже мебели и товаров для дома.",
                 "vendorexadel@gmail.com", "Olof Palmestraat 1, 2616 LN Delft, Нидерланды", "+31503168772", "{\"instagram\": \"https://www.instagram.com/ikeausa/ \", \"facebook\": \"https://www.facebook.com/IKEAUSA/ \", \"twitter\" : \"https://twitter.com/ikea \", \"vk\": \"https://vk.com/ikea \", \"webSite\" : \"https://www.ikea.com/ \"} ");
            AddVendor("Chanel", @"Chanel is a French fashion house that focuses on women's high fashion and ready-to-wear clothes, luxury goods and accessories. The company is owned by Alain Wertheimer and Gérard Wertheimer, grandsons of Pierre Wertheimer, who was an early business partner of the couturière Coco Chanel.",
                "vendorexadel@gmail.com", "France, Paris, Neuilly-sur-Seine 135 Avenue Charles de Gaulle", "+33 1 42 60 58 58", "{\"instagram\": \"https://www.instagram.com/chanelofficial/ \", \"facebook\": \"https://www.facebook.com/chanel/ \", \"twitter\" : \"https://twitter.com/chanel \", \"vk\": \"https://vk.com/chanelofficial \", \"webSite\" : \"https://www.chanel.com/us/ \"} ");
            AddVendor("L’Oreal", @"L`Oreal Paris (Лореаль) - один из ведущих косметических брендов мира, мы предлагаем вам профессиональные косметические средства для тела, лица и волос",
                "vendorexadel@gmail.com", @"4-6 Rue Bertrand Sincholle, 92110 Clichy, Франция", "+7 (495) 258 31 91", "{\"instagram\": \"https://www.instagram.com/lorealparis/ \", \"facebook\": \"https://www.facebook.com/loreal \", \"twitter\" : \"https://twitter.com/loreal \", \"vk\": \"https://vk.com/lorealparisrussia \", \"webSite\" : \"https://loreal-paris.ru \"} ");
            AddVendor("Belwest", @" Belwest - этомультибрендовая торговая сеть, представляющая мужскую, женскую, детскую обувь и аксессуары из натуральной кожи. В интернет-магазине belwest.by представлен широкий ассортимент высококачественной обуви разного стиля и сезона. ",
                "vendorexadel@gmail.com", @" Беларусь, 210026 г. Витебск, пр-т Генерала Людникова, 10", "+375(29) 899 11 88", "{\"instagram\": \"https://www.instagram.com/adidas/?hl=ru \", \"facebook\": \"https://www.facebook.com/belwest.shoes \", \"twitter\" : \"https://vk.com/belwest.shoes \", \"vk\": \"https://vk.com/originals \", \"webSite\" : \"https://belwest.by/ru \"} ");
            AddVendor("Adidas", @" Adidas - крупнейший бренд, создающий одежду и обувь для занятий спортом с использованием передовых технологий. Это коллекции, которые помогают добиваться максимальных результатов в любом виде спорта как начинающим, так и профессиональным атлетам.",
                "vendorexadel@gmail.com", @"220121, Беларусь, г. Минск, ул. Глебки, д.2, офис 13а", "+375(29) 2 495 495", "{\"instagram\": \"https://www.instagram.com/lorealparis/ \", \"facebook\": \"https://www.facebook.com/adidas \", \"twitter\" : \"https://twitter.com/loreal \", \"vk\": \"https://vk.com/lorealparisrussia \", \"webSite\" : \"https://www.adidas.ru \"} ");
            AddVendor("Vitra", @" Компания Vitra специализируется на производстве сантехники, керамической плитки и керамогранита. У ней вы сможете приобрести все необходимые товары для вашего дома",
                "vendorexadel@gmail.com", @"Vitra International AG, a Swiss corporation Klünenfeldstrasse 22 4127 Birsfelden Switzerland", "+41 61 377 00 00", "{\"instagram\": \"https://www.instagram.com/vitra \", \"facebook\": \"https://www.facebook.com/vitra \", \"twitter\" : \"https://twitter.com/vitra \", \"vk\": \"https://vk.com/vitrarussia \", \"webSite\" : \"https://www.vitra.com/en-un/home \"} ");
        }

        public void AddVendor(string name, string description, string email, string address, string phone, string socialLinks)
        {
            _context.Vendors.Add(new Vendor()
            {
                Name = name,
                Description = description,
                Email = email,
                Address = address,
                Phone = phone,
                SocialLinks = socialLinks,
            });

            _context.SaveChanges();
        }
    }
}
