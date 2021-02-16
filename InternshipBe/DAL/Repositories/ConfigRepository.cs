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

        public async Task<ConfigVariable> GetConfigByNameAsync(string name)
        {
            var config = await _entities.Where(p => p.Name == name).SingleOrDefaultAsync();

            return config;
        }

        public async Task<int> GetRadiusAsync()
        {
            var radius = await GetConfigByNameAsync("Radius");

            return int.Parse(radius.Value);
        }

        public async Task<bool> IsSendingEmailsEnabled()
        {
            var sendingEmailToggler = await GetConfigByNameAsync("SendingEmailToggler");

            return bool.Parse(sendingEmailToggler.Value);
        }
    }
}