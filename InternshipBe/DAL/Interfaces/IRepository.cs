using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);

        Task CreateAsync(TEntity item);

        Task<IQueryable<TEntity>> GetSpecifiedAmountAsync(int skip, int take);
    }
}
