using DAL.DataContext;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DAL.DbInitializer
{
    public class UserInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private const string password = "Qwerty123!";

        public UserInitializer(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeUsers()
        {
            await AddUser(1, "admnexadel@gmail.com", "admin", "admin", "admin", "+375447777777", true, _context.Offices.Find(1), RoleNames.Admin);

            await AddUser(1, "moderatorexadel@gmail.com", "moderator", "moderator", "moderator", "+375447777777", true, _context.Offices.Find(1), RoleNames.Moderator);

            await AddUser(1, "userexadel@gmail.com", "demoUser", "demoUser", "demoUser", "+375447777777", true, _context.Offices.Find(1), RoleNames.User);

            await AddUser(1, "userMinsk@test.com", "офис", "Минск", "Минск", "+375447777777", false, _context.Offices.Find(1), RoleNames.User);

            await AddUser(2, "userGomel@test.com", "офис", "Гомель", "Гомель", "+375447777777", true, _context.Offices.Find(2), RoleNames.User);

            await AddUser(3, "userWarszawa@test.com", "офис", "Варшава", "Варшава", "+48 228 236 200", true, _context.Offices.Find(3), RoleNames.User);

            await AddUser(4, "userTashkent@test.com", "офис", "Ташкент", "Ташкент", "+78-140-09-09", true, _context.Offices.Find(4), RoleNames.User);
           
            await AddUser(5, "userUsa@test.com", "офис", "Walnut Creek", "Walnut Creek", "+1 (916) 555 0166", true, _context.Offices.Find(5), RoleNames.User);

            Random random = new Random();

            for (int i = 0; i < 1200; i++)
            {
                var officeId = random.Next(1, 5);
                await AddUser(officeId, $"user{i}@test.com", $"firstName{i}", $"lastName{i}", $"patronymic{i}", $"+375447777777", true, _context.Offices.Find(officeId), RoleNames.User);
            }
        }

        public async Task AddUser(int officeId, string email, string firstName, string LastName, string patronymic, string phone, bool activityStatus, Office office, string role)
        {
            var user = new User()
            {
                OfficeId = officeId,
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = LastName,
                Patronymic = patronymic,
                Phone = phone,
                ActivityStatus = activityStatus,
                Office = office,
            };

            await _userManager.CreateAsync(user, password);

            if (role == RoleNames.User)
            {
                await _userManager.AddToRolesAsync(await _userManager.FindByNameAsync(email), RoleNames.GetRolesOfUser());
            }
            else if (role == RoleNames.Moderator)
            {
                await _userManager.AddToRolesAsync(await _userManager.FindByNameAsync(email), RoleNames.GetRolesOfModerator());
            }
            else
            {
                await _userManager.AddToRolesAsync(await _userManager.FindByNameAsync(email), RoleNames.GetRolesOfAdmin());
            }

            _context.SaveChanges();
        }
    }
}
