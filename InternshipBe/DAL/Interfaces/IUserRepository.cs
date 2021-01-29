using DAL.Entities;
using System.Linq;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Office GetUserOffice(int officeId);

        IQueryable<string> GetUserRoles(int userId);
    }
}
