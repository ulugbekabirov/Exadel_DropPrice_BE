using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IConfigRepository : IRepository<ConfigVariable>
    {
        Task<IEnumerable<ConfigVariable>> GetConfigs();

        ConfigVariable GetConfig(int id);
    }
}
