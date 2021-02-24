using DAL.DataContext;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;
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
            await SeedDatabase(userManager, rolesManager);
        }

        public static async Task SeedDatabase(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            var configInitializer = new ConfigVariablesInitializer(_context);
            configInitializer.InitializeConfigVariables();

            if (!_context.ConfigVariables.Where(p => p.Name == "Radius").Any())
            {
                _context.ConfigVariables.Add(new ConfigVariable
                {
                    Name = "Radius",
                    Value = "40000",
                    Description = "Radius in meters",
                    DataType = DataTypes.Number,
                });
                _context.SaveChanges();
            }

            if (!_context.ConfigVariables.Where(p => p.Name == "SendingEmailToggler").Any())
            {
                _context.ConfigVariables.Add(new ConfigVariable
                {
                    Name = "SendingEmailToggler",
                    Value = "false",
                    Description = "Toggler to indicate whether to send emails or not",
                    DataType = DataTypes.Boolean,
                });
                _context.SaveChanges();
            }

            var emailTemplates = new EmailsInitializer(_context);
            emailTemplates.InitializeEmails();

            if (userManager.Users.Any())
            {
                return;
            }

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole<int>(RoleNames.Admin));
                await roleManager.CreateAsync(new IdentityRole<int>(RoleNames.Moderator));
                await roleManager.CreateAsync(new IdentityRole<int>(RoleNames.User));
            }

            var towns = new TownInitializer(_context);
            towns.InitializeTowns();

            var offices = new OfficeInitializer(_context);
            offices.InitializeOffices();

            var users = new UserInitializer(_context, userManager);
            await users.InitializeUsers();

            var pointOfSales = new PointOfSaleInitializer(_context);
            pointOfSales.InitializePointOfSales();

            var vendors = new VendorInitializer(_context);
            vendors.InitializeVendors();

            var tags = new TagInitializer(_context);
            tags.InitializeTags();

            var discounts = new DiscountInitializer(_context);
            discounts.InitializeDiscounts();

            var assessments = new AssessmentInitializer(_context);
            assessments.InitializerAssesments();

            var tickets = new TicketInitializer(_context);
            tickets.InitializeTickets();

            _context.SaveChanges();
        }
    }
}
