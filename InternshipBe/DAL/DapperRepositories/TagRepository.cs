using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DapperRepositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public Task<IEnumerable<Tag>> GetExistingTagsAsync(IEnumerable<string> tagNames)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetPopularTagsAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
