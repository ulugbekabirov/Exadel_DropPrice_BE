using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var specifiedAmount = await GetSpecifiedAmountAsync(skip, take);

            return specifiedAmount.OrderBy(d => d.Discounts.Count);
        }
    }
}
