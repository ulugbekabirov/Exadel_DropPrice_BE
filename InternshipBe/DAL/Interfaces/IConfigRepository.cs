using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IConfigRepository : IRepository<ConfigVariable>
    {
        Task<IEnumerable<ConfigVariable>> GetConfigsAsync();

        Task<ConfigVariable> GetConfigAsync(int id);
    }
}
