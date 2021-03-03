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

        public void AddAssesment(string email, int discountId, int value)
        {
            var userId = _context.Users.SingleOrDefault(u => u.Email == email).Id;
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
        private void AddMultipleAssesments(string email, int discountIdStart, int discountIdStop)
        {
            var rnd = new Random();

            for(; discountIdStart <= discountIdStop; discountIdStart++)
            {
                AddAssesment(email, discountIdStart, rnd.Next(1,5));
            }
        }

        public void InitializerAssesments()
        {
            AddMultipleAssesments("userGomel@test.com", 8, 43);
            AddMultipleAssesments("userWarszawa@test.com", 1, 64);
            AddMultipleAssesments("userTashkent@test.com"), 32, 85);
            AddMultipleAssesments("userUsa@test.com"), 61, 98);
            AddMultipleAssesments("userTashkent@test.com"), 32, 85);
            AddMultipleAssesments("user0@test.com"), 86, 96);
            AddMultipleAssesments("user3@test.com"), 86, 98);
            AddMultipleAssesments("user1@test.com"), 1, 32);
            AddMultipleAssesments("user2@test.com"), 26, 53);
            AddMultipleAssesments("user4@test.com"), 4, 60);
            AddMultipleAssesments("user5@test.com"), 1, 85);
            AddMultipleAssesments("user7@test.com"), 64, 85);
            AddMultipleAssesments("user8@test.com"), 32, 70);
            AddMultipleAssesments("user9@test.com"), 1, 76);
        }
    }
}
