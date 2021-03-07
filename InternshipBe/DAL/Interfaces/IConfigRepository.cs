using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IConfigRepository : IRepository<ConfigVariable>
    {
        Task<IEnumerable<ConfigVariable>> GetConfigsAsync();

        Task<int> GetRadiusAsync(int id);

        Task<bool> IsSendingEmailsEnabled(int id);

        Task<MessageTemplates> SetEmailLocalizationAsync();

        Task<int> GetDiscountEditTimeAsync(int id);
    }
}
