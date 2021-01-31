using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IQueryable<Tag>> GetPopularAsync(int skip, int take)
        {
            var tags = await _entities.Skip(skip).Take(take).ToListAsync();
            return tags.AsQueryable();
        }
    }
}
