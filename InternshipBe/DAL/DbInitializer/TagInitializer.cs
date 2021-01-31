using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    public class TagInitializer
    {
        private readonly ApplicationDbContext _db;

        public TagInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InitializeTags()
        {
            AddTag("CoffePlus");
            AddTag("Coffee");
            AddTag("TheBestCoffee");
            AddTag("Food");
            AddTag("Reebok");
        }
        
        public void AddTag(string name)
        {
            _db.Tags.Add(new Tag
            {
                Name = name,
            });
        }
    }
}
