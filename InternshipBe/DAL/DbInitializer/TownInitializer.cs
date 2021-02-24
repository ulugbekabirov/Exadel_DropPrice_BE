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

        public void AddTown(string nameRussian, string NameEnglish, double latitude, double longitude)
        {
            var localizedName = new LocalizedName()
            {
                Russian = nameRussian,
                English = NameEnglish,
            };

            var town = new Town()
            {
                Name = localizedName,
                Latitude = latitude,
                Longitude = longitude,
            };

            _context.Towns.Add(town);

            _context.SaveChanges();
        }

        public void InitializeTowns()
        {
            AddTown("Минск", "Minsk", 53.9005961, 27.5589895);
            AddTown("Гомель", "Gomel", 52.4313156, 30.9938049);
            AddTown("Ташкент", "Tashkent", 41.2994958, 69.2400734);
            AddTown("Уолнат - Крик", "Walnut Creek", 37.9100754, -122.0653152);
            AddTown("Варшава", "Warszawa", 52.231164, 21.0113525); 
            AddTown("Витебск", "Vitebsk", 55.193419, 30.2038716);
        }
    }
}
