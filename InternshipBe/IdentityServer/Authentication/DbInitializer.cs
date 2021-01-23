using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Authentication
{
    public class DbInitializer
    {
        private static readonly string password = "Qwerty123!";

        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager.Users.Any())
            {
                return;
            }

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Moderator"));
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "admin@exadel.com",
                Email = "admin@exadel.com",
            };

            ApplicationUser moderator = new ApplicationUser()
            {
                UserName = $"moderator@exadel.com",
                Email = $"moderator@exadel.com",
            };

            await userManager.CreateAsync(moderator, password);
            await userManager.AddToRolesAsync(moderator, new string[] { "Moderator", "User" });

            await userManager.CreateAsync(admin, password);
            await userManager.AddToRolesAsync(admin, new string[] {"Admin", "Moderator", "User" });

            for (int i = 0; i < 1200; i++)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = $"user{i}@exadel.com",
                    Email = $"user{i}@exadel.com",
                };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
