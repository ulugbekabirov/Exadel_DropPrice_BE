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
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 3, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 4, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 5, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 6, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 7, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 8, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 9, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 16, 4);

            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 5, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 6, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 8, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 2, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 4, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 18, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 25, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 31, 3);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 9, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 10, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 7, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 16, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 17, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 18, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 20, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 22, 4);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 8, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 10, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 15, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 28, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 29, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 30, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 31, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 25, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 23, 4);

            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 6, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 9, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 7, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 17, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 19, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 21, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 24, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 22, 5);

            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 1, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 2, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 7, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 13, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 17, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 18, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 21, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 27, 4);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 9, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 10, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 6, 5);
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
            _context.Users.Find(userId).Assessments.Add(assessment);
            _context.Discounts.Find(discountId).Assessments.Add(assessment);

            _context.SaveChanges();
        }
    }
}
