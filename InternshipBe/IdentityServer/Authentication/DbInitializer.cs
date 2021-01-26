using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Authentication
{
    public class DbInitializer
    {
        private static readonly string password = "Qwerty123!";

        public static async Task InitializeDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var rolesManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await PopulateUsersAndRoles(userManager, rolesManager);
        }

        public static async Task PopulateUsersAndRoles(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager.Users.Any())
            {
                return;
            }

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(RoleName.Admin));
                await roleManager.CreateAsync(new IdentityRole(RoleName.Moderator));
                await roleManager.CreateAsync(new IdentityRole(RoleName.User));
            }

            var admin = new User()
            {
                UserName = "admnexadel@gmail.com",
                Email = "admnexadel@gmail.com",
            };

            var moderator = new User()
            {
                UserName = "moderatorexadel@gmail.com",
                Email = "moderatorexadel@gmail.com",
            };

            var demoUser = new User()
            {
                UserName = "userexadel@gmail.com",
                Email = "userexadel@gmail.com",
            };

            await userManager.CreateAsync(demoUser, password);
            await userManager.AddToRolesAsync(demoUser, RoleName.GetRolesOfUser() );

            await userManager.CreateAsync(moderator, password);
            await userManager.AddToRolesAsync(moderator, RoleName.GetRolesOfModerator());

            await userManager.CreateAsync(admin, password);
            await userManager.AddToRolesAsync(admin, RoleName.GetRolesOfAdmin());

            for (int i = 0; i < 1200; i++)
            {
                var user = new User()
                {
                    UserName = $"user{i}@test.com",
                    Email = $"user{i}@test.com",
                };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRolesAsync(user, RoleName.GetRolesOfUser());
            }
        }
    }
}
