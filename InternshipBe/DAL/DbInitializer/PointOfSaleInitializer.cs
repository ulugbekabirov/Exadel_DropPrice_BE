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
