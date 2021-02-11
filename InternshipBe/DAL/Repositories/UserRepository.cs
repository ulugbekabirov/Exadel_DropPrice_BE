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
            return await _context.Roles.Where(r => _context.UserRoles.Where(u => u.UserId == userId).Select(u => u.RoleId).Contains(r.Id)).Select(r => r.Name).ToListAsync();
        }
        //public async Task<SavedDiscount> GetUserSaves(int discountId, int userId)
        //{
        //    return await _context.SavedDiscounts.Where(d => d.DiscountId == discountId && d.UserId == userId).ToListAsync();
        //}
        public async Task<IEnumerable<SavedDiscount>> GetUserSavedAsync(int userId)//
        {
            return await _context.SavedDiscounts.Where((u => u.UserId == userId)).ToListAsync();/*.Select(u => u.DiscountId).Contains(r.Id)).Select(r => r.Name).ToListAsync();*/
        }
        
    }
}
