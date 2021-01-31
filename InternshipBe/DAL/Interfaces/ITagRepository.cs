using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<IQueryable<Tag>> GetPopularAsync(int skip, int take);
    }
}
