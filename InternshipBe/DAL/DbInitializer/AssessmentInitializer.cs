using DAL.DataContext;
using DAL.Entities;
using System;
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
        private void AddMultipleAssesments(int userId, int discountIdStart, int discountIdStop)
        {
            var rnd = new Random();

            for(; discountIdStart <= discountIdStop; discountIdStart++)
            {
                AddAssesment(userId, discountIdStart, rnd.Next(1,5));
            }
        }

        public void InitializerAssesments()
        {
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "userGomel@test.com").Id, 8, 43);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "userWarszawa@test.com").Id, 1, 64);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 32, 85);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "userUsa@test.com").Id, 61, 98);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "userTashkent@test.com").Id, 32, 85);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user0@test.com").Id, 86, 96);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user3@test.com").Id, 86, 98);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user1@test.com").Id, 1, 32);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user2@test.com").Id, 26, 53);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user4@test.com").Id, 4, 60);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user5@test.com").Id, 1, 85);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user7@test.com").Id, 64, 85);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user8@test.com").Id, 32, 70);
            AddMultipleAssesments(_context.Users.SingleOrDefault(u => u.Email == "user9@test.com").Id, 1, 76);
        }
    }
}
