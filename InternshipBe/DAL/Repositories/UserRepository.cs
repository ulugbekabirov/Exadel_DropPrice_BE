using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<string> GetUserRoles(int userId)
        {
            return _context.Roles
                .Where(r => _context.UserRoles.Where(u => u.UserId == userId).Select(u => u.RoleId).Contains(r.Id))
                .Select(r => r.Name);
        }
    }
}
