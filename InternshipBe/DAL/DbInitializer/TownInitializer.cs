using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class TownInitializer
    {
        private readonly ApplicationDbContext _context;

        public TownInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeTowns()
        {
            AddTown("Минск", 53.9005961, 27.5589895);
            AddTown("Гомель", 52.4313156, 30.9938049);
            AddTown("Ташкент", 41.2994958, 69.2400734);
            AddTown("Walnut Creek", 37.9100754, -122.0653152);
            AddTown("Варшава", 52.231164, 21.0113525); 
            AddTown("Витебск", 55.193419, 30.2038716);
        }

        public void AddTown(string name, double latitude, double longitude)
        {
            _context.Towns.Add(new Town()
            {
                Name = name,
                Latitude = latitude,
                Longitude = longitude,
            });

            _context.SaveChanges();
        }
    }
}
