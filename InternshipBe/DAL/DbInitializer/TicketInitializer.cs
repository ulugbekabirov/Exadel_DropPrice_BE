using DAL.DataContext;
using DAL.Entities;
using System.Linq;

namespace DAL.DbInitializer
{
    public class TicketInitializer
    {
        private readonly ApplicationDbContext _db;

        public TicketInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InitializerTickets()
        {
            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 1);
            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 2);
            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "admnexadel@gmail.com").Id, 3);

            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 4);
            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 5);
            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "moderatorexadel@gmail.com").Id, 6);

            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 7);
            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 8);
            AddTicket(_db.Users.SingleOrDefault(u => u.Email == "userexadel@gmail.com").Id, 9);
        }

        public void AddTicket(int userId, int discountId)
        {
            var ticket = new Ticket()
            {
                UserId = userId,
                DiscountId = discountId,
            };

            _db.Tickets.Add(ticket);

            _db.SaveChanges();

            _db.Users.Find(userId).Tickets.Add(ticket);
            _db.Discounts.Find(discountId).Tickets.Add(ticket);

            _db.SaveChanges();
        }
    }
}
