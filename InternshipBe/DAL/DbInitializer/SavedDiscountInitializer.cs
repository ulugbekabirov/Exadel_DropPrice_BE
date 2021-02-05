using DAL.DataContext;
using DAL.Entities;
using System.Linq;

namespace DAL.DbInitializer
{
    public class SavedDiscountInitializer
    {
        private readonly ApplicationDbContext _context;

        public SavedDiscountInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeSavedDiscounts()
        {
            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 1);
            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 2);
            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 3);

            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 4);
            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 5);
            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 6);

            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 7);
            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 8);
            AddSavedDiscount(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 9);
        }

        public void AddSavedDiscount(int userId, int discountId)
        {
            var savedDiscount = new SavedDiscount()
            {
                UserId = userId,
                DiscountId =discountId,
            };

            _context.SavedDiscounts.Add(savedDiscount);
            _context.Users.Find(userId).SavedDiscounts.Add(savedDiscount);
            _context.Discounts.Find(discountId).SavedDiscounts.Add(savedDiscount);

            _context.SaveChanges();
        }
    }
}
