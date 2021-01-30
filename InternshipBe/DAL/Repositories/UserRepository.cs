using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IQueryable<string>> GetUserRoles(int userId)
        {
            var roles = await _context.Roles
                                .Where(r => _context.UserRoles.Where(u => u.UserId == userId).Select(u => u.RoleId).Contains(r.Id))
                                .Select(r => r.Name).ToListAsync();

            return  roles.AsQueryable();
        }
    }
}
