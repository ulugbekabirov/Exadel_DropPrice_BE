using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class PointOfSaleInitializer
    {
        private readonly ApplicationDbContext _db;

        public PointOfSaleInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InitializePointOfSales()
        {
            AddPointOfSales("Coffee in Minsk", "проспект Дзержинского 87, Минск 220089", 53.8601961, 27.484121);
            AddPointOfSales("Coffee", "площадь Свободы 5, Минск", 53.9025312, 27.5557145);
            AddPointOfSales("Coffee in Grodno", "ул. Дарвина 24, Гродно 230011", 53.6713253, 23.8239813);

            AddPointOfSales("Food in Minsk", "улица Пономаренко 35а, Минск 220015", 53.8928202, 27.4925566);
            AddPointOfSales("Food", "Władysława Raginisa 5, 15-161 Białystok, Польша", 53.1507469, 23.1876433);
            AddPointOfSales("Food in Тошкент", "9 Shota Rustaveli ko'chasi, Тошкент, Узбекистан", 41.2950347, 69.2681766);

            AddPointOfSales("Reebok", "Tashkent 100173, Узбекистан", 41.2945188, 69.1936755);
            AddPointOfSales("Reebok in Minsk", "пр-т. Победителей 65, Минск", 53.9269855, 27.5166321);
            AddPointOfSales("Reebok in Grodno", "ул. Суворова 254а, Гродно 230001", 53.6523708, 23.7923098);
        }

        public void AddPointOfSales(string name, string address, double latitude, double longitude)
        {
            _db.PointOfSales.Add(new PointOfSale()
            {
                Name = name,
                Address = address,
                Latitude = latitude,
                Longitude = longitude,
            });
        }
    }
}
