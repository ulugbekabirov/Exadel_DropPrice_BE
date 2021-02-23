using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Infrastructure;
using System.Threading;

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

        public async Task<IEnumerable<ConfigVariable>> EmailLocalization()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            if (currentCulture!=null)
            {
                return await _entities.Where(c => c.Name.Contains(currentCulture + "MessageFor")).ToListAsync();
            }
            else
            {
                return await _entities.Where(c => c.Name.Contains("RuMessageFor")).ToListAsync();
            }
        }
    }
}