using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(int userId)
        {
            return await _context.Roles.Where(r => _context.UserRoles.Where(u => u.UserId == userId).Select(u => u.RoleId).Contains(r.Id)).Select(r => r.Name).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Discount>> GetSavedDiscountsAsync(int userId, int skip, int take)
        {
            return await _context.SavedDiscounts.Where(s => s.UserId == userId && s.IsSaved == true).Skip(skip).Take(take).Select(d => d.Discount).AsNoTracking().ToListAsync();
        }
    }
}
