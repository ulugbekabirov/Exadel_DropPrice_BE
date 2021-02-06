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
            AddPointOfSales("IKEA Ташкент", "3-A улица Темур Малик, дом, Тошкент 100015, Uzbekistan", 41.353240, 69.352407);
            AddPointOfSales("IKEA Гомель", "Рэчыцкі праспект 5В, Гомель 246027", 52.416728, 30.961430);

            AddPointOfSales("KFC Минск", "ул. Бобруйская 19, Минск", 53.8906515, 27.5547945);
            AddPointOfSales("KFC Гомель", "ул. Советская 19, Гомель 246022", 52.4287905, 31.0127735);
            AddPointOfSales("KFC Ташкент", "Мирзо-Улугбекский район, ул.Буюк Ипак йули  д105", 41.326804, 69.330765);
            AddPointOfSales("KFC Warszawa", "Polska, wieś Opacz-Kolonia, aleja Jerozolimskie, 11/19", 52.230824, 21.017336);
            AddPointOfSales("KFC Walnut Creek", "635 Contra Costa Blvd, Pleasant Hill, CA 94523, United States", 37.957380, -122.037167);

            AddPointOfSales("Chanel Boutique Ташкент", "11-uy, Bunyodkor Avenue, Tashkent 100115, Uzbekistan", 41.293243, 69.225569);
            AddPointOfSales("AnnaClair Минск", "ул. В. Хоружей 1а, ТЦ «Силуэт» 1 этаж ряд 6 место 9, Minsk 220005, Belarus", 53.916285, 27.581274);
            AddPointOfSales("Cravt Минск", "ТЦ «Титан», Prospekt Dzerzhinskogo 104/2, Minsk 220089, Belarus", 53.860912, 27.476941);
            AddPointOfSales("Cravt Гомель", "Проспект Леніна 47, Гомель 246017", 52.429199, 30.998394);
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
