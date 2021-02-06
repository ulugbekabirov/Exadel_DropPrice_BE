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
            AddPointOfSales("Пицца темпо Громова", "ул. Громова 20, Минск", 53.8535645, 27.4444699);
            AddPointOfSales("Пицца темпо Бобруйская", "ул. Бобруйская 6, Минск", 53.8904302, 27.5539899);
            AddPointOfSales("Пицца темпо Мстиславца", "ул. Петра Мстиславца 11, Минск 220020", 53.9336182, 27.6521158);

            AddPointOfSales("KFC Бобруйская", "ул. Бобруйская 19, Минск", 53.8906515, 27.5547945);
            AddPointOfSales("KFC Dana Mall", "ул. Петра Мстиславца 11, Минск", 53.9336182, 27.6521158);
            AddPointOfSales("KFC Советская", "ул. Советская 19, Гомель 246022", 52.4287905, 31.0127735);
            AddPointOfSales("KFC Кристall", "ул. Ильича 333, Гомель 246013", 52.3568891, 31.0290813);
            AddPointOfSales("KFC Fayz", "д. 105, Тошкент, Узбекистан", 41.3267623, 69.3308544);
            AddPointOfSales("KFC Чиланзар", "Tashkent 100097, Узбекистан", 41.2753875, 69.2044044);
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
