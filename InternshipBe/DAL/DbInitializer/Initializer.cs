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
        private static ApplicationDbContext _context;

        public static async Task InitializeDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var rolesManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
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

            var towns = new TownInitializer(_context);
            towns.InitializeTowns();

            var offices = new OfficeInitializer(_context);
            offices.InitializeOffices();

            var users = new UserInitializer(_context, userManager);
            await users.InitializeUsers();

            var vendors = new VendorInitializer(_context);
            vendors.InitializeVendors();

            var tags = new TagInitializer(_context);
            tags.InitializeTags();

            var pointOfSales = new PointOfSaleInitializer(_context);
            pointOfSales.InitializePointOfSales();

            var discounts = new DiscountInitializer(_context);
            discounts.InitializeDiscounts();

            var savedDicounts = new SavedDiscountInitializer(_context);
            savedDicounts.InitializeSavedDiscounts();

            var tickets = new TicketInitializer(_context);
            tickets.InitializerTickets();

            var assessments = new AssessmentInitializer(_context);
            assessments.InitializerAssesments();

            _context.ConfigVariables.Add(new ConfigVariable
            {
                Name = "Radius",
                Value = "40000",
                Description = "Radius in meters"
            });

            _context.SaveChanges();
        }
    }
}
