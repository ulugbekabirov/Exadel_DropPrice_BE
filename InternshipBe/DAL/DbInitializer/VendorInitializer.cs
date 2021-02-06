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
            AddVendor("Пицца Темпо", @"Пицца Темпо – крупнейшая сеть пиццерий в Республике Беларусь: 20 уютных пиццерий расположились в городе Минске, Гродно, Могилеве и Молодечно более 1 500 000 пицц ежегодно радуют наших Гостей в залах пиццерий и с доставкой", "vendorexadel@gmail.com", "г.Минск, пр-т Победителей 89, комн.", "+375 (017) 375-77-73", "https://www.instagram.com/pizzatempo/");
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
