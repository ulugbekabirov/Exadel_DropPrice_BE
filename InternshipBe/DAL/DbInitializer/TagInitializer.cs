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

        public void InitializeTags()
        {
            AddTag("Кондитерские изделия");
            AddTag("Фастфуд");
            AddTag("Напитки");
            AddTag("Пицца");
            AddTag("Уютное место");
            AddTag("Еда навынос");
            AddTag("Доставка");
        }
        
        public void AddTag(string name)
        {
            _context.Tags.Add(new Tag
            {
                Name = name,
            });

            _context.SaveChanges();
        }
    }
}
