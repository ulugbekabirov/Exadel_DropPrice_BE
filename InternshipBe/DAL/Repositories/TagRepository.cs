using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<Tag> GetPopularTags(int skip, int take)
        {
            return _entities.Include(t => t.Discounts).ThenInclude(t => t.Tags).Skip(skip).Take(take);
        }
    }
}
