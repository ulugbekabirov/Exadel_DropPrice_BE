using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<IEnumerable<Tag>> GetExistingTagsAsync(IEnumerable<string> tagNames);

        Task<IEnumerable<Tag>> GetPopularTagsAsync(int skip, int take);
    }
}
