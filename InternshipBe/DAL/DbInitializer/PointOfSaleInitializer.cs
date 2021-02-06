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
            AddPointOfSales("Evos Lavash Center М.Юсуфа", "Мирзо-Улугбекский район ул.МУХАММАДА ЮСУФА, 1А", 41.324068, 69.326089);
            AddPointOfSales("Evos Lavash Center А.Дониша", "Юнусабадский район ул.АХМАДА ДОНИША, кв - л ЮНУСАБАД - 5, 11 / 1", 41.342615, 69.264924);
            AddPointOfSales("Evos Lavash Center Мукими", "Яккасарайский район ул.МУКИМИ", 41.280040, 69.241771);

            AddPointOfSales("Пицца темпо Громова", "ул. Громова 20, Минск", 53.8535645, 27.4444699);
            AddPointOfSales("Пицца темпо Бобруйская", "ул. Бобруйская 6, Минск", 53.8904302, 27.5539899);
            AddPointOfSales("Пицца темпо Мстиславца", "ул. Петра Мстиславца 11, Минск 220020", 53.9336182, 27.6521158);



            AddPointOfSales("IKEA USA", "4400 Shellmound St, Emeryville, CA 94608, Соединенные Штаты", 37.8317513, -122.2919726);
            AddPointOfSales("IKEA Warszawa", "al. Jerozolimskie 179, 02-222 Warszawa, Польша", 52.2126557, 20.9560347);
            AddPointOfSales("IKEA Минск", "улица Кульман 11 Минск BY, 220108", 53.9221336, 27.5770569);

            AddPointOfSales("KFC Минск", "ул. Бобруйская 19, Минск", 53.8906515, 27.5547945);
            AddPointOfSales("KFC Гомель", "ул. Советская 19, Гомель 246022", 52.4287905, 31.0127735);
            AddPointOfSales("KFC Ташкент", "Мирзо-Улугбекский район, ул.Буюк Ипак йули  д105", 41.326804, 69.330765);
            AddPointOfSales("KFC Warszawa", "Polska, wieś Opacz-Kolonia, aleja Jerozolimskie, 11/19", 52.230824, 21.017336);
            AddPointOfSales("KFC Walnut Creek", "635 Contra Costa Blvd, Pleasant Hill, CA 94523, United States", 37.957380, -122.037167);
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
