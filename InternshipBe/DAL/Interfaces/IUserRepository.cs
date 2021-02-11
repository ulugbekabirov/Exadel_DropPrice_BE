using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<Discount>> GetSavedDiscountsAsync(int userId, int skip, int take);

        Task<IEnumerable<string>> GetUserRolesAsync(int userId);
    }
}
