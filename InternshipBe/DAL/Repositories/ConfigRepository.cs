using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<MessageTemplates> SetEmailLocalizationAsync()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            if (currentCulture == "en")
            {
                var MessageTemplate = new MessageTemplates
                {
                    UserTemplate = await _entities.Where(c => c.Id == 3).Select(c => c.Value).SingleAsync(),
                    VendorTemplate = await _entities.Where(c => c.Id == 4).Select(c => c.Value).SingleAsync()
                };
                return MessageTemplate;
            }
            else if (currentCulture == "ru")
            {
                var MessageTemplate = new MessageTemplates
                {
                    UserTemplate = await _entities.Where(c => c.Id == 5).Select(c => c.Value).SingleAsync(),
                    VendorTemplate = await _entities.Where(c => c.Id == 6).Select(c => c.Value).SingleAsync()
                };
                return MessageTemplate;
            }
            else
            {
                var MessageTemplate = new MessageTemplates
                {
                    UserTemplate = await _entities.Where(c => c.Id == 5).Select(c => c.Value).SingleAsync(),
                    VendorTemplate = await _entities.Where(c => c.Id == 6).Select(c => c.Value).SingleAsync()
                };
                return MessageTemplate;
            }

        }
    }
}