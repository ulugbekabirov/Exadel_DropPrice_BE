using DAL.DataContext;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DbInitializer
{
    public class Initializer
    {
        private static ApplicationDbContext _db;

        public static async Task InitializeDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var rolesManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await PopulateUsersAndRoles(userManager, rolesManager);
        }

        public static async Task PopulateUsersAndRoles(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            if (userManager.Users.Any())
            {
                return;
            }

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole<int>(RolesName.Admin));
                await roleManager.CreateAsync(new IdentityRole<int>(RolesName.Moderator));
                await roleManager.CreateAsync(new IdentityRole<int>(RolesName.User));
            }

            var towns = new TownInitializer(_db);
            towns.InitializeTowns();

            var offices = new OfficeInitializer(_db);
            offices.InitializeOffices();

            var users = new UserInitializer(_db, userManager);
            await users.InitializeUsers();

            var vendors = new VendorInitializer(_db);
            vendors.InitializeVendors();

            var tags = new TagInitializer(_db);
            tags.InitializeTags();

            var pointOfSales = new PointOfSaleInitializer(_db);
            pointOfSales.InitializePointOfSales();

            var discounts = new DiscountInitializer(_db);
            discounts.InitializeDiscounts();

            var savedDicounts = new SavedDiscountInitializer(_db);
            savedDicounts.InitializeSavedDiscounts();

            var tickets = new TicketInitializer(_db);
            tickets.InitializerTickets();

            var assessments = new AssessmentInitializer(_db);
            assessments.InitializerAssesments();

            _db.SaveChanges();
        }
    }
}
