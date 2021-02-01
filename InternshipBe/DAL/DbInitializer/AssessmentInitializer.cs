using DAL.DataContext;
using DAL.Entities;
using System.Linq;

namespace DAL.DbInitializer
{
    public class AssessmentInitializer
    {
        private readonly ApplicationDbContext _context;

        public AssessmentInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializerAssesments()
        {
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 1, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 2, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 3, 3);

            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 4, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 5, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 6, 5);

            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 7, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 8, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 9, 2);
        }

        public void AddAssesment(int userId, int discountId, int value)
        {
            var assessment = new Assessment()
            {
                UserId = userId,
                DiscountId = discountId,
                AssessmentValue = value,
            };

            _context.Assessments.Add(assessment);

            _context.SaveChanges();

            _context.Users.Find(userId).Assessments.Add(assessment);
            _context.Discounts.Find(discountId).Assessments.Add(assessment);

            _context.SaveChanges();
        }
    }
}
