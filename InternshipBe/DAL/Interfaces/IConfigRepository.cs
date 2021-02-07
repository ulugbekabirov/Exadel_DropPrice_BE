using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IConfigRepository : IRepository<ConfigVariable>
    {
        ConfigVariable GetConfig();
    }
}
