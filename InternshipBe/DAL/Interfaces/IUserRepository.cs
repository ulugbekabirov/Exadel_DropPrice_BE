using DAL.Entities;
using System.Linq;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<string> GetUserRoles(int userId);
    }
}
