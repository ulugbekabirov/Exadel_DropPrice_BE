using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IConfigRepository : IRepository<ConfigVariable>
    {
        Task<IEnumerable<ConfigVariable>> GetConfigsAsync();

        Task<int> GetRadiusAsync(int id);

        Task<bool> IsSendingEmailsEnabled(int id);

        Task<IEnumerable<ConfigVariable>> EmailLocalization(string currentCulture);
    }
}
