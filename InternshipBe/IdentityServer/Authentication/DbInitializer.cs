using DAL.DataContext;
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
        private static ApplicationDbContext _db;

        public static async Task InitializeDatabase(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var rolesManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await PopulateUsersAndRoles(userManager, rolesManager);
        }

        private static void AddTowns()
        {
            var town1 = new Town()
            {
                Name = "Минск",
                Latitude = 53.9005961,
                Longitude = 27.5589895,
            };

            var town2 = new Town()
            {
                Name = "Гродно",
                Latitude = 53.6688496,
                Longitude = 23.8221359,
            };

            _db.Towns.AddRange(town1, town2);
            _db.SaveChanges();
        }

        private static void AddOffices()
        {
            var officeMinsk = new Office()
            {
                Name = "Exadel",
                Address = "ул. Академика Купревича 3, Минск 220141",
                Latitude = 53.9275383,
                Longitude = 27.6833072,
            };

            var officeGrodno = new Office()
            {
                Name = "Exadel",
                Address = "ул. Максима Горького 1/1, Гродно 230023",
                Latitude = 53.6863386,
                Longitude = 23.8310623,
            };

            _db.Offices.AddRange(officeMinsk, officeGrodno);
            _db.SaveChanges();
        }

        private static void AddVendors()
        {
            var vendorNike = new Vendor()
            {
                Name = "Nike",
                Description = "vendor nice snickers",
                Address = "пер. Северный 13/5, Минск 220036",
                Email = "vendorexadel@gmail.com",
                Phone = "375447777777",
            };

            var vendorCoffee = new Vendor()
            {
                Name = "Coffee",
                Description = "Nice coffee",
                Address = "проспект Дзержинского 11, Минск 220089",
                Email = "vendorexadel@gmail.com",
                Phone = "375447777777",
            };

            _db.Vendors.AddRange(vendorNike, vendorCoffee);
            _db.SaveChanges();
        }

        private static void AddTags()
        {
            var tagCoffee = new Tag()
            {
                Name = "Coffee",
            };

            var tagNike = new Tag()
            {
                Name = "Snickers",
            };

            _db.Tags.AddRange(tagCoffee, tagNike);
            _db.SaveChanges();
        }

        private static void AddDiscount()
        {
            for (int i = 0; i < 5; i++)
            {
                var discount = new Discount()
                {
                    Vendorid = 1,
                    Name = $"snickers{i}",
                    Description = $"discount{i} nice snikers",
                    DiscountAmount = i * i,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)),
                    ActivityStatus = true,
                };

                discount.Tags.Add(_db.Tags.Find(1));
                _db.Discounts.Add(discount);
            }

            for (int i = 0; i < 5; i++)
            {
                var discount = new Discount()
                {
                    Vendorid = 2,
                    Name = $"coffee{i}",
                    Description = $"discount{i} cheap coffee",
                    DiscountAmount = i * i,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)),
                    ActivityStatus = true,
                };

                discount.Tags.Add(_db.Tags.Find(2));
                _db.Discounts.Add(discount);
            }
        }

        private static void AddPointOfSales()
        {
            var pointOfSalesCoffee = new PointOfSale() //Minsk
            {
                Name = "Coffee",
                Address = "проспект Дзержинского 104, Минск 220089",
                Latitude = 53.8607142,
                Longitude = 27.4797061,
            };

            var pointOfSalesNike = new PointOfSale() // Grodno
            {
                Name = "Nike",
                Address = "ул. Суворова 254а, Гродно 230001",
                Latitude = 53.6523708,
                Longitude = 23.7923098,
            };

            _db.PointOfSales.AddRange(pointOfSalesCoffee, pointOfSalesNike);
            _db.SaveChanges();
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

            AddTowns();

            AddOffices();

            AddVendors();

            AddTags();

            AddPointOfSales();

            AddDiscount();

            //UsersWithRalationShip
            var admin = new User()
            {
                UserName = "admnexadel@gmail.com",
                Email = "admnexadel@gmail.com",
                OfficeId = 1,
                FirstName = $"admin",
                LastName = $"admin",
                Phone = $"375447777777",
                ActivityStatus = true,
            };

            var moderator = new User()
            {
                UserName = "moderatorexadel@gmail.com",
                Email = "moderatorexadel@gmail.com",
                OfficeId = 1,
                FirstName = $"moderator",
                LastName = $"moderator",
                Phone = $"375447777777",
                ActivityStatus = true,
            };

            var demoUser = new User()
            {
                UserName = "userexadel@gmail.com",
                Email = "userexadel@gmail.com",
                OfficeId = 1,
                FirstName = $"user",
                LastName = $"user",
                Phone = $"375447777777",
                ActivityStatus = true,
            };

            await userManager.CreateAsync(admin, password);
            await userManager.AddToRolesAsync(admin, RoleName.GetRolesOfAdmin());

            await userManager.CreateAsync(moderator, password);
            await userManager.AddToRolesAsync(moderator, RoleName.GetRolesOfModerator());

            await userManager.CreateAsync(demoUser, password);
            await userManager.AddToRolesAsync(demoUser, RoleName.GetRolesOfUser());

            var savedDiscount = new SavedDiscount()
            {
                DiscountId = 6,
                UserId = demoUser.Id,
            };

            var ticker = new Ticket()
            {
                DiscountId = 4,
                UserId = demoUser.Id,
                OrderDate = DateTime.Now,
            };

            _db.SavedDiscounts.Add(savedDiscount);
            _db.Tickets.Add(ticker);

            for (int i = 0; i < 5; i++)
            {
                var user = new User()
                {
                    UserName = $"user{i}@test.com",
                    Email = $"user{i}@test.com",
                    OfficeId = 2,
                    FirstName = $"user{i}",
                    LastName = $"user{i}",
                    Phone = $"37544{i}{i}{i}{i}{i}{i}{i}",
                    ActivityStatus = true,
                };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRolesAsync(user, RoleName.GetRolesOfUser());

                var savedDiscount1 = new SavedDiscount()
                {
                    DiscountId = 7,
                    UserId = user.Id,
                };

                var ticker1 = new Ticket()
                {
                    DiscountId = 1,
                    UserId = user.Id,
                    OrderDate = DateTime.Now,
                };

                _db.SavedDiscounts.Add(savedDiscount1);
                _db.Tickets.Add(ticker1);
            }

            _db.SaveChanges();
        }
    }
}
