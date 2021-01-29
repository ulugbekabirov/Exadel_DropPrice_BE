using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface ITagRepository : IRepository<Tag>
    {
        IQueryable<Tag> GetPopularTags(int skip, int take);
    }
}
