using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ConfigRepository : Repository<ConfigVariable>, IConfigRepository
    {
        public ConfigRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ConfigVariable>> GetConfigsAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<ConfigVariable> GetConfigAsync(int id)
        {
            var config = await _entities.Where(p => p.Id == id).SingleOrDefaultAsync();

            return config;
        }
    }
}