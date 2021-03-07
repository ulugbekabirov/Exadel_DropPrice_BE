using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class TagInitializer 
    {
        private readonly ApplicationDbContext _context;

        public TagInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTag(string name)
        {
            _context.Tags.Add(new Tag
            {
                Name = name,
            });

            _context.SaveChanges();
        }

        public void InitializeTags()
        {
            AddTag("кондитерские изделия");
            AddTag("фастфуд");
            AddTag("напитки");
            AddTag("пицца");
            AddTag("уютное место");
            AddTag("еда навынос");
            AddTag("доставка");
            AddTag("KFC");
            AddTag("курица");
            AddTag("мебель");
            AddTag("дешево");
            AddTag("для дома"); 
            AddTag("выгодно");
            AddTag("быстро");
            AddTag("вкусно");
            AddTag("мода");
            AddTag("парфюмерия");
            AddTag("уход за кожей");
            AddTag("роскошь");
            AddTag("одежда");
            AddTag("обувь");
            AddTag("красота");
            AddTag("макияж");
            AddTag("дорого");
            AddTag("тренировка");
            AddTag("голод");
            AddTag("лекарство");
            AddTag("духи");
            AddTag("светильник");       
            AddTag("сантеника");
            AddTag("уют");
            AddTag("электротехника");   
            AddTag("комфорт");
            AddTag("equipment");
            AddTag("for home");
        }
    }
}
