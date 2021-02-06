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
                "vendorexadel@gmail.com", @"Мирзо-Улугбекский ул.МУХАММАДА ЮСУФА, 1А", "+998 71 2031212", "https://www.instagram.com/evosuzbekistan/");
            AddVendor("Food", "The best food", "vendorexadel@gmail.com", "ул. Максима Горького 1/1, Гродно 230023", "+375447777777", "www.instagram.com/vendor");
            AddVendor("Reebok", "The best snickers", "vendorexadel@gmail.com","Inkubator Technologiczny, Żurawia 71, 15-540 Białystok, Польша", "+375447777777", "www.instagram.com/vendor");
        }

        public void AddVendor(string name, string description, string email, string address, string phone, string socialNetworkLink)
        {
            _context.Vendors.Add(new Vendor()
            {
                Name = name,
                Description = description,
                Email = email,
                Address = address,
                Phone = phone,
                SocialNetworkLink = socialNetworkLink,
            });

            _context.SaveChanges();
        }
    }
}
