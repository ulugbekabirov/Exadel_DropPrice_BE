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

        public async Task<int> GetRadiusAsync(int id)
        {
            var radius = await GetByIdAsync(id);

            return int.Parse(radius.Value);
        }

        public async Task<bool> IsSendingEmailsEnabled(int id)
        {
            var sendingEmailToggler = await GetByIdAsync(id);

            return bool.Parse(sendingEmailToggler.Value);
        }

        public async Task<List<string>> EmailLocalization(string currentCulture = "eng")
        {
            if (currentCulture == "eng")
            {
                return await _entities.Where(c => c.Name.Contains("ENG")).Select(c => c.Value).ToListAsync();
            }
            else
            {
                return await _entities.Where(c => c.Name.Contains("RUS")).Select(c => c.Value).ToListAsync();
            }
        }
    }
}