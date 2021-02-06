using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class OfficeInitializer
    {
        private readonly ApplicationDbContext _context;

        public OfficeInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeOffices()
        {
            AddOffice("Минск", "ул. Академика Купревича 3, Минск 220141", 53.9275383, 27.6833072);
            AddOffice("Гродно", "ул. Максима Горького 1/1, Гродно 230023", 53.6863386, 23.8310623);
            AddOffice("Гомель", "ул. Пушкина 2-9", 52.4334088, 31.0102844);
            AddOffice("Варшава", "Warsaw Corporate Center ul. Emilii Plater 28", 52.227656, 21.005916);
            AddOffice("Белосток", "Inkubator Technologiczny, Żurawia 71, 15-540 Białystok, Польша", 53.1069075, 23.1933832);
            AddOffice("Ташкент", "Mirzo Ulugbek District Tamara Khanun str. 20,", 41.319297, 69.301804);
            AddOffice("Walnut Creek", "1340 Treat Blvd. Suite 375, Walnut Creek CA 94597", 37.92554, -122.058403); ;
        }

        public void AddOffice(string name, string address, double latitude, double longitude)
        {
            _context.Offices.Add(new Office()
            {
                Name = name,
                Address = address,
                Latitude = latitude,
                Longitude = longitude,
            });

            _context.SaveChanges();
        }
    }
}
