using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IHintsRepository : IRepository<Discount>
    {
        Task<IEnumerable<string>> SearchHintsAsync(string subString, int take);
    }
}
