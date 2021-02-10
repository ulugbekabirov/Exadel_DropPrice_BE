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
                "vendorexadel@gmail.com", @"Мирзо-Улугбекский ул.МУХАММАДА ЮСУФА, 1А", "+998 71 2031212", "{\"Instagram\": \"https://www.instagram.com/evosuzbekistan/ \", \"Facebook\": \"https://www.facebook.com/evosuzbekistan/ \", \"Twitter\" : null, \"Vk\": null, \"WebSite\" : \"https://evos.uz/ \") ");
            AddVendor("Пицца Темпо", @"Пицца Темпо – крупнейшая сеть пиццерий в Республике Беларусь: 20 уютных пиццерий расположились в городе Минске, Гродно, Могилеве и Молодечно более 1 500 000 пицц ежегодно радуют наших Гостей в залах пиццерий и с доставкой", 
                "vendorexadel@gmail.com", "г.Минск, пр-т Победителей 89, комн.", "+375 (017) 375-77-73", "{\"Instagram\": \"https://www.instagram.com/pizzatempo/ \", \"Facebook\": \"https://www.facebook.com/pizzatempo.by?fref=ts \", \"Twitter\" : \"https://twitter.com/pizzatempo_by \", \"Vk\": \"https://vk.com/tempoby \", \"WebSite\" : \"https://www.pizzatempo.by/ \") ");
            AddVendor("KFC", @"Kentucky Fried Chicken, сокращённо KFC — международная сеть ресторанов общественного питания, специализирующаяся на блюдах из курицы. Штаб-квартира компании располагается в городе Луисвилле в штате Кентукки. KFC — вторая по торговому обороту сеть кафе в мире, уступающая лишь компании McDonald's.",
                "vendorexadel@gmail.com", "Луисвилл, Кентукки, США", "+375296470730", "{\"Instagram\": \"https://www.instagram.com/kfc/ \", \"Facebook\": \"https://www.facebook.com/KFC/ \", \"Twitter\" : \"https://twitter.com/kfc \", \"Vk\": \"https://vk.com/kfcbelarusofficial \", \"WebSite\" : \"https://www.kfc.com/menu \") ");
            AddVendor("IKEA", @"IKEA — основанная в Швеции нидерландская производственно - торговая группа компаний, владелец одной из крупнейших в мире торговых сетей по продаже мебели и товаров для дома.",
                 "vendorexadel@gmail.com", "Olof Palmestraat 1, 2616 LN Delft, Нидерланды", "+31503168772", "{\"Instagram\": \"https://www.instagram.com/ikeausa/ \", \"Facebook\": \"https://www.facebook.com/IKEAUSA/ \", \"Twitter\" : \"https://twitter.com/ikea \", \"Vk\": \"https://vk.com/ikea \", \"WebSite\" : \"https://www.ikea.com/ \") ");
            AddVendor("Chanel", @"Chanel is a French fashion house that focuses on women's high fashion and ready-to-wear clothes, luxury goods and accessories. The company is owned by Alain Wertheimer and Gérard Wertheimer, grandsons of Pierre Wertheimer, who was an early business partner of the couturière Coco Chanel.",
                "vendorexadel@gmail.com", "France, Paris, Neuilly-sur-Seine 135 Avenue Charles de Gaulle", "+33 1 42 60 58 58", "{\"Instagram\": \"https://www.instagram.com/chanelofficial/ \", \"Facebook\": \"https://www.facebook.com/chanel/ \", \"Twitter\" : \"https://twitter.com/chanel \", \"Vk\": \"https://vk.com/chanelofficial \", \"WebSite\" : \"https://www.chanel.com/us/ \") ");
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
                SocialLinks = socialLinks
            });

            _context.SaveChanges();
        }
    }
}
