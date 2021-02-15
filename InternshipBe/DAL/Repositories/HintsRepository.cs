using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class HintsRepository : Repository<Discount>, IHintsRepository
    {
        public HintsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<string>> SearchHintsAsync(string subString, int take)
        {
            return await _entities.Where(s => s.Name.Contains(subString)).Take(take).Select(d => d.Name).ToListAsync();
        }
    }
}
