using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Shared.Infrastructure;
using Shared.Middleware.Localization;

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

            switch (currentCulture)
            {
                case Cultures.English:
                    var EnMessageTemplate = new MessageTemplates
                    {
                        UserTemplate = await _entities.Where(c => c.Id == (int)ConfigIdentifiers.EnMessageForUser).Select(c => c.Value).SingleAsync(),
                        VendorTemplate = await _entities.Where(c => c.Id == (int)ConfigIdentifiers.EnMessageForVendor).Select(c => c.Value).SingleAsync()
                    };
                    return EnMessageTemplate;

                case Cultures.Russian:
                    var RuMessageTemplate = new MessageTemplates
                    {
                        UserTemplate = await _entities.Where(c => c.Id == (int)ConfigIdentifiers.RuMessageForUser).Select(c => c.Value).SingleAsync(),
                        VendorTemplate = await _entities.Where(c => c.Id == (int)ConfigIdentifiers.RuMessageForVendor).Select(c => c.Value).SingleAsync()
                    };
                    return RuMessageTemplate;

                default:
                    var DefaultMessageTemplate = new MessageTemplates
                    {
                        UserTemplate = await _entities.Where(c => c.Id == (int)ConfigIdentifiers.RuMessageForUser).Select(c => c.Value).SingleAsync(),
                        VendorTemplate = await _entities.Where(c => c.Id == (int)ConfigIdentifiers.RuMessageForVendor).Select(c => c.Value).SingleAsync()
                    };
                    return DefaultMessageTemplate;
            }
        }
    }
}