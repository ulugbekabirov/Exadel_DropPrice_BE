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
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 2, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 2, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 2, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 2, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 2, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 2, 4);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 9, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 10, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 61, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 62, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 63, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 64, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 65, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 66, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 67, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 68, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 69, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 86, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 87, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 88, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 89, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 90, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 92, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 91, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 93, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 94, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 95, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 96, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 97, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 98, 3);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 6, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 87, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 8, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 89, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 90, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 7, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 91, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 93, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 10, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 95, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 11, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 97, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 98, 4);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 8, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 9, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 63, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 64, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 65, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 66, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 67, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 68, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 10, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 86, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 87, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 88, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 11, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 90, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 92, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 6, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 93, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 94, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 95, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 7, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 97, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 98, 4);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 8, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 10, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 15, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 28, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 29, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 30, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 31, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 25, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 12, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 13, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 31, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 32, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 34, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 36, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 37, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 41, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 51, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 53, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 54, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 61, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 62, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 65, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 68, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 71, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 72, 3);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 26, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 27, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 28, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 31, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 34, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 35, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 36, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 37, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 41, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 42, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 43, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 44, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 55, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 56, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 57, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 58, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 59, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 60, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 69, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 63, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 66, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 67, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 73, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 74, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 75, 3);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 21, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 22, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 27, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 32, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 33, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 38, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 39, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 40, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 42, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 45, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 64, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 65, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 66, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 67, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 72, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 73, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 78, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 81, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 82, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 84, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 85, 5);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 61, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 62, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 63, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 64, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 65, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 66, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 67, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 68, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 10, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 86, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 87, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 88, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 11, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 89, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 92, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 93, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 94, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 96, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 7, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 97, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 98, 5);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 6, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 7, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 11, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 12, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 24, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 35, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 37, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 38, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 45, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 46, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 48, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 49, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 51, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 52, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 53, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 57, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 58, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 61, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 63, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 66, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 68, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 69, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 73, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 81, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 84, 3);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 8, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 12, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 13, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 14, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 17, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 18, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 21, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 22, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 25, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 27, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 32, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 36, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 44, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 55, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 56, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 59, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 60, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 62, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user6@test.com").Id, 65, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 70, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 72, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 76, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 78, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 79, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 85, 3);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 1, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 2, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 3, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 6, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 7, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 8, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 24, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 27, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 28, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 31, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 36, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 37, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 38, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 46, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 47, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 49, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 50, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 56, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 63, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 65, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 66, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 73, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 75, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 78, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 83, 3);


            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 27, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 29, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 30, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 34, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 37, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 39, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 43, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 51, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 53, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 55, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 57, 5);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 59, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 60, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 68, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 69, 2);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 70, 1);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 77, 3);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 82, 4);
            AddAssesment(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 84, 3);
        }
    }
}
