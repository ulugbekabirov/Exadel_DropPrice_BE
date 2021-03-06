using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DapperRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public Task<IEnumerable<Discount>> GetSavedDiscountsAsync(int userId, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetUserRolesAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
