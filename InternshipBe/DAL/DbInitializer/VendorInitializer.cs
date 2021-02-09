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
                "vendorexadel@gmail.com", @"Мирзо-Улугбекский ул.МУХАММАДА ЮСУФА, 1А", "+998 71 2031212", "https://www.instagram.com/evosuzbekistan/", "https://www.facebook.com/pastauz", null, null, "https://www.pasta.uz/");
            AddVendor("Пицца Темпо", @"Пицца Темпо – крупнейшая сеть пиццерий в Республике Беларусь: 20 уютных пиццерий расположились в городе Минске, Гродно, Могилеве и Молодечно более 1 500 000 пицц ежегодно радуют наших Гостей в залах пиццерий и с доставкой", 
                "vendorexadel@gmail.com", "г.Минск, пр-т Победителей 89, комн.", "+375 (017) 375-77-73", "https://www.instagram.com/pizzatempo/", "https://www.facebook.com/pizzatempo.by?fref=ts", "https://twitter.com/pizzatempo_by", "https://vk.com/tempoby", "https://www.pizzatempo.by/");
            AddVendor("KFC", @"Kentucky Fried Chicken, сокращённо KFC — международная сеть ресторанов общественного питания, специализирующаяся на блюдах из курицы. Штаб-квартира компании располагается в городе Луисвилле в штате Кентукки. KFC — вторая по торговому обороту сеть кафе в мире, уступающая лишь компании McDonald's.",
                "vendorexadel@gmail.com", "Луисвилл, Кентукки, США", "+375296470730", "https://www.instagram.com/kfc/", "https://www.facebook.com/KFC/", "https://twitter.com/kfc", "https://vk.com/kfcbelarusofficial", "https://www.kfc.com/menu");
            AddVendor("IKEA", @"IKEA — основанная в Швеции нидерландская производственно - торговая группа компаний, владелец одной из крупнейших в мире торговых сетей по продаже мебели и товаров для дома.",
                 "vendorexadel@gmail.com", "Olof Palmestraat 1, 2616 LN Delft, Нидерланды", "+31503168772", "https://www.instagram.com/ikeausa/", "https://www.facebook.com/IKEAUSA/", "https://twitter.com/ikea", "https://vk.com/ikea", "https://www.ikea.com/");
            AddVendor("Chanel", @"Chanel is a French fashion house that focuses on women's high fashion and ready-to-wear clothes, luxury goods and accessories. The company is owned by Alain Wertheimer and Gérard Wertheimer, grandsons of Pierre Wertheimer, who was an early business partner of the couturière Coco Chanel.",
                "vendorexadel@gmail.com", "France, Paris, Neuilly-sur-Seine 135 Avenue Charles de Gaulle", "+33 1 42 60 58 58", "https://www.instagram.com/chanelofficial/", "https://www.facebook.com/chanel/", "https://twitter.com/chanel", "https://vk.com/chanelofficial", "https://www.chanel.com/us/");
        }

        public void AddVendor(string name, string description, string email, string address, string phone, string instagramLink, string facebookLink, string twitterLink, string vkLink, string webSiteLink)
        {
            _context.Vendors.Add(new Vendor()
            {
                Name = name,
                Description = description,
                Email = email,
                Address = address,
                Phone = phone,
                InstagramLink = instagramLink,
                FacebookLink = facebookLink,
                TwitterLink = twitterLink,
                VkLink = vkLink,
                WebSiteLink = webSiteLink,
            });

            _context.SaveChanges();
        }
    }
}
