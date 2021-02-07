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
            AddTag("CoffeePlus");
            AddTag("Coffee");
            AddTag("TheBestCoffee");
            AddTag("Food");
            AddTag("Reebok");
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
