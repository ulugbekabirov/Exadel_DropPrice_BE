using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class TownInitializer
    {
        private ApplicationDbContext _db;

        public TownInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InitializeTowns()
        {
            AddTown("Минск", 53.9005961, 27.5589895);
            AddTown("Гродно", 53.6688496, 23.8221359);
            AddTown("Ташкент", 41.2994958, 69.2400734);
        }

        public void AddTown(string name, double latitude, double longitude)
        {
            _db.Towns.Add(new Town()
            {
                Name = name,
                Latitude = latitude,
                Longitude = longitude,
            });

            _db.SaveChanges();
        }
    }
}
