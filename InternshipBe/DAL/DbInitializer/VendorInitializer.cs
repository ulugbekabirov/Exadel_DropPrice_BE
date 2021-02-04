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
            AddVendor("Coffee", "The best coffee", "vendorexadel@gmail.com", "ул. Академика Купревича 3, Минск 220141", "+375447777777", "www.instagram.com/vendor");
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
