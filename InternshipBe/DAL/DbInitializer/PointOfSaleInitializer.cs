using DAL.DataContext;
using DAL.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace DAL.DbInitializer
{
    public class PointOfSaleInitializer
    {
        private readonly ApplicationDbContext _context;

        public PointOfSaleInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPointOfSales(string name, string address, double latitude, double longitude)
        {
            var location = NtsGeometryServices.Instance
                .CreateGeometryFactory(srid: 4326)
                .CreatePoint(new Coordinate(longitude, latitude));

            _context.PointOfSales.Add(new PointOfSale()
            {
                Name = name,
                Address = address,
                Location = location,
            });

            _context.SaveChanges();
        }

        public void InitializePointOfSales()
        {
            AddPointOfSales("Evos Lavash Center М.Юсуфа", "Мирзо-Улугбекский район ул.МУХАММАДА ЮСУФА, 1А", 41.324068, 69.326089);
            AddPointOfSales("Evos Lavash Center А.Дониша", "Юнусабадский район ул.АХМАДА ДОНИША, кв - л ЮНУСАБАД - 5, 11 / 1", 41.342615, 69.264924);
            AddPointOfSales("Evos Lavash Center Мукими", "Яккасарайский район ул.МУКИМИ", 41.280040, 69.241771);

            AddPointOfSales("Пицца темпо Громова", "ул. Громова 20, Минск", 53.8535645, 27.4444699);
            AddPointOfSales("Пицца темпо Бобруйская", "ул. Бобруйская 6, Минск", 53.8904302, 27.5539899);
            AddPointOfSales("Пицца темпо Мстиславца", "ул. Петра Мстиславца 11, Минск 220020", 53.9336182, 27.6521158);

            AddPointOfSales("IKEA USA", "4400 Shellmound St, Emeryville, CA 94608, United States", 37.8317513, -122.2919726);
            AddPointOfSales("IKEA Warszawa", "al. Jerozolimskie 179, 02-222 Warszawa", 52.2126557, 20.9560347);
            AddPointOfSales("IKEA Минск", "улица Кульман 11 Минск, 220108", 53.9221336, 27.5770569);
            AddPointOfSales("IKEA Ташкент", "3-A улица Темур Малик, дом, Тошкент 100015, Узбекистан", 41.353240, 69.352407);
            AddPointOfSales("IKEA Гомель", "Речицкий проспект 5В, Гомель 246027", 52.416728, 30.961430);

            AddPointOfSales("KFC Минск", "ул. Бобруйская 19, Минск", 53.8906515, 27.5547945);
            AddPointOfSales("KFC Гомель", "ул. Советская 19, Гомель 246022", 52.4287905, 31.0127735);
            AddPointOfSales("KFC Ташкент", "Мирзо-Улугбекский район, ул.Буюк Ипак йули  д105", 41.326804, 69.330765);
            AddPointOfSales("KFC Warszawa", "Polska, wieś Opacz-Kolonia, aleja Jerozolimskie, 11/19", 52.230824, 21.017336);
            AddPointOfSales("KFC Walnut Creek", "635 Contra Costa Blvd, Pleasant Hill, CA 94523, United States", 37.957380, -122.037167);

            AddPointOfSales("Chanel Boutique Ташкент", "11-uy, Bunyodkor Avenue, Tashkent 100115, Uzbekistan", 41.293243, 69.225569);
            AddPointOfSales("AnnaClair Минск", "ул. В. Хоружей 1а, ТЦ «Силуэт» 1 этаж ряд 6 место 9, Минск 220005", 53.916285, 27.581274);
            AddPointOfSales("Cravt Минск", "ТЦ «Титан», Проспект Джержинского 104/2, Минск 220089", 53.860912, 27.476941);
            AddPointOfSales("Cravt Гомель", "Проспект Ленина 47, Гомель 246017", 52.429199, 30.998394);

            AddPointOfSales("Магазин косметики в Минске на Боровой", "7А Боровая, Минская область 223053 ", 53.9767861, 27.6558762);
            AddPointOfSales("УП Дипмаркет", "ул. Коммунистическая 54, Минск ", 53.9304701, 27.56745574);
            AddPointOfSales("Магазин профессиональной косметики Cosmopro.by", "Пр. Победителей, 65, ТЦ «Замок» 1 этаж, место 55, Минск", 53.9440347, 27.5259872);
            AddPointOfSales("L'Oreal Poland Sp. zoo", "Grzybowska 62, 00-844 Warszawa", 52.2430251, 20.9971225);

            AddPointOfSales("Belwest ТЦ Столица", "ТЦ Столица, проспект Независимости 3, Минск 220030", 53.9010416, 27.5439724);
            AddPointOfSales("Belwest Минск", "Проспект Независимости 58, Минск 220089 ", 53.9216424, 27.5919754);
            AddPointOfSales("Belwest ТД Неман", "ТД Неман, Советская ул. 18, Гродно 230023", 53.6827264, 23.8299878);
            AddPointOfSales("BELWEST Витебск", "просп. Генерала Людникова 10, Витебск 210026", 55.2041642, 30.2203299);
            AddPointOfSales("Belwest ТК Корона", "ул. Максима Горького 91, Гродно 230015", 53.7109096, 23.8171491);

            AddPointOfSales("Adidas Гродно", "ул. Дубко 17, Гродно 230005", 53.7773534, 23.7782460);
            AddPointOfSales("Футбольный магазин soccershop.by", "г.Минск, ул. Немига, д. 3 нулевой этаж магазин №30 Минск BY, 220030", 53.9119530, 27.5509915);
            AddPointOfSales("Adidas Минск", "ул. Петра Мстиславца 11, Минск", 53.9372809, 27.6453697);
            AddPointOfSales("Adidas Ташкент", "60 проспект Амира Темура, Ташкент, Узбекистан", 41.3235649, 69.2833072);

            AddPointOfSales("Гемма - строительный магазин", "просп. Космонавтов 2Г, Гродно 230025", 53.6790926, 23.8464561);
            AddPointOfSales("Магазин Santehlux", "улица Тимирязева д.44, Минск 220035", 53.9747383, 27.5619366);
            AddPointOfSales("VitrA Home salon firmowy Bartycka 24 paw.228", "Bartycka 24/26/pawilon 228, Warszawa", 52.2440627, 21.0515890);
            AddPointOfSales("VitrA Узбекистан", "Barakat business centre, Afrosiab, 2, Tashkent", 41.3032844, 69.2679597);

            AddPointOfSales("Сервисный центр ИП \"Роберт Бош\"", "020, улица Тимирязева 65а, Минск", 53.9490416, 27.5188690);
            AddPointOfSales("MAJSTER BOSCH", "Konstantego Ciołkowskiego 24, 15-264 Białystok, Польша", 53.1467102, 23.2363017);
            AddPointOfSales("Bosch Hrodna", "ул. Пушкина 31а, Гродно 230012", 53.7035534, 23.8387627);
            AddPointOfSales("Magazin Bosh - Elektrotekhnika Dlya Doma", "Ул. Руставелли (Усмана Носыра) 32а, Тошкент, Узбекистан", 41.2953083, 69.2561120);

            AddPointOfSales("Electrolux Ташкент", "Amir Temur Avenue, Tashkent, Узбекистан", 41.3312303, 69.2846146);
            AddPointOfSales("Электросила Минск", "ул. Красная 22, Минск 220005", 53.9197060, 27.5856844);
            AddPointOfSales("Электросила Гродно", "ТЦ Корона, просп.Космонавтов 81, Гродно 230019", 53.7059679, 23.8408464);

            AddPointOfSales("Stanley Walnut Creek", "2044 MT DIABLO BLVD WALNUT CREEK, CA 94596", 37.897450, -122.069288);

            AddPointOfSales("Head & Shoulders Минск", "г.Минск, пр-т Дзержинского, 106", 53.858273, 27.475387);
            AddPointOfSales("Head & Shoulders Гомель", "г.Гомель, улица Кирова 23", 52.426476, 30.990455);
            AddPointOfSales("Head & Shoulders Витебск", "г.Витебск, улица Петруся Бровки", 55.162177, 30.237293);

            AddPointOfSales("Gillette Минск", "г.Минск, пр-т Дзержинского, 106", 53.858273, 27.475387);
            AddPointOfSales("Gillette Гомель", "г.Гомель, улица Кирова 23", 52.426476, 30.990455);
            AddPointOfSales("Gillette Витебск", "г.Витебск, улица Петруся Бровки", 55.162177, 30.237293);

            AddPointOfSales("Canon Walnut Creek", "1350 Treat Blvd Suite 150, Walnut Creek, CA 94597, United States", 37.926605, -122.056194);
            AddPointOfSales("Canon Warszawa", "Daimlera 2 / V piętro, 02 - 460 Warszawa, Poland", 52.205285, 20.939259);
            
        }
    }
}
