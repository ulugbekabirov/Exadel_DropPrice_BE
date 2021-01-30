using DAL.DataContext;
using DAL.Entities;
using System.Linq;

namespace DAL.DbInitializer
{
    public class SavedDiscountInitializer
    {
        private ApplicationDbContext _db;

        public SavedDiscountInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InitializeSavedDiscounts()
        {
            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 1);
            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 2);
            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 3);

            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 4);
            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 5);
            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 6);

            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 7);
            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 8);
            AddSavedDiscount(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 9);
        }

        public void AddSavedDiscount(int userId, int discountId)
        {
            var savedDiscount = new SavedDiscount()
            {
                UserId = userId,
                DiscountId =discountId,
            };

            _db.SavedDiscounts.Add(savedDiscount);

            _db.SaveChanges();

            _db.Users.Find(userId).SavedDiscounts.Add(savedDiscount);
            _db.Discounts.Find(discountId).SavedDiscounts.Add(savedDiscount);

            _db.SaveChanges();
        }
    }
}
