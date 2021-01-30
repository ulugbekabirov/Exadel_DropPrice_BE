using DAL.DataContext;
using DAL.Entities;
using System.Linq;

namespace DAL.DbInitializer
{
    public class AssessmentInitializer
    {
        private readonly ApplicationDbContext _db;

        public AssessmentInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InitializerAssesments()
        {
            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 1);
            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 2);
            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 3);

            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 4);
            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 5);
            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 6);

            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 7);
            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 8);
            AddAssesment(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 9);
        }

        public void AddAssesment(int userId, int discountId)
        {
            var assessment = new Assessment()
            {
                UserId = userId,
                DiscountId = discountId,
            };

            _db.Assessments.Add(assessment);

            _db.SaveChanges();

            _db.Users.Find(userId).Assessments.Add(assessment);
            _db.Discounts.Find(discountId).Assessments.Add(assessment);

            _db.SaveChanges();
        }
    }
}
