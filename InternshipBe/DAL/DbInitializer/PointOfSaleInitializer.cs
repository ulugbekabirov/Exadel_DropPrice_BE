using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class PointOfSaleInitializer
    {
        private readonly ApplicationDbContext _context;

        public PointOfSaleInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializePointOfSales()
        {
            AddPointOfSales("Coffee in Minsk", "проспект Дзержинского 87, Минск 220089", 53.8601961, 27.484121);
            AddPointOfSales("Coffee", "площадь Свободы 5, Минск", 53.9025312, 27.5557145);
            AddPointOfSales("Coffee in Grodno", "ул. Дарвина 24, Гродно 230011", 53.6713253, 23.8239813);

            AddPointOfSales("Food in Minsk", "улица Пономаренко 35а, Минск 220015", 53.8928202, 27.4925566);
            AddPointOfSales("Food", "Władysława Raginisa 5, 15-161 Białystok, Польша", 53.1507469, 23.1876433);
            AddPointOfSales("Food", "9 Shota Rustaveli ko'chasi, Тошкент, Узбекистан", 41.2950347, 69.2681766);

            AddPointOfSales("Reebok", "Tashkent 100173, Узбекистан", 41.2945188, 69.1936755);
            AddPointOfSales("Reebok in Minsk", "пр-т. Победителей 65, Минск", 53.9269855, 27.5166321);
            AddPointOfSales("Reebok in Grodno", "ул. Суворова 254а, Гродно 230001", 53.6523708, 23.7923098);

            AddPointOfSales("KFC Rossini", "Ташкент, Шайхантахурский район, массив Хадра, 23", 41.3289341, 69.2478162);
            AddPointOfSales("KFC in Minsk", "пр-т. Независимости 23, Минск", 53.9062502, 27.5520951);
            AddPointOfSales("KFC Triniti", "просп. Я. Купалы 87, Гродно 230026", 53.6502601, 23.8557723);

            AddPointOfSales("Mcdonalds in Minsk", "пр-т. Независимости 23, Минск", 53.9013598, 27.5597421);
            AddPointOfSales("Mcdonalds Galileo", "ул. Бобруйская, 6, Минск", 53.8905815, 27.5534423);
            AddPointOfSales("Mcdonalds in Grodno", "ул. Горновых 9, Гродно", 53.6694679, 23.8215089);

        }

        public void AddPointOfSales(string name, string address, double latitude, double longitude)
        {
            _context.PointOfSales.Add(new PointOfSale()
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
