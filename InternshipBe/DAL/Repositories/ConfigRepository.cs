using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System.Linq;

namespace DAL.Repositories
{
    public class ConfigRepository : Repository<ConfigVariable>, IConfigRepository
    {
        public ConfigRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ConfigVariable GetConfig()
        {
            var config = _context.ConfigVariables.Where(p => p.Id == 1).SingleOrDefault();

            return config;
        }
    }
}