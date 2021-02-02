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
            AddVendor("Coffee", "The best coffee", "vendorexadel@gmail.com", "+375447777777", null);
            AddVendor("Food", "The best food", "vendorexadel@gmail.com", "+375447777777", null);
            AddVendor("Reebok", "The best snickers", "vendorexadel@gmail.com", "+375447777777", null);
        }

        public void AddVendor(string name, string description, string email, string phone, string socialNetworkLink)
        {
            _context.Vendors.Add(new Vendor()
            {
                Name = name,
                Description = description,
                Email = email,
                Phone = phone,
                SocialNetworkLink = socialNetworkLink,
            });

            _context.SaveChanges();
        }
    }
}
