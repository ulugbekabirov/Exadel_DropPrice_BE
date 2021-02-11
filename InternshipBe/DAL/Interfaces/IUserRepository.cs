using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<string>> GetUserRolesAsync(int userId);

        Task<IEnumerable<SavedDiscount>> GetUserSavedAsync(int userId);

        
    }
}
