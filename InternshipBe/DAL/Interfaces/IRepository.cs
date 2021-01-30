using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);

        Task Create(TEntity item);

        Task<IQueryable<TEntity>> GetSpecifiedAmount(int skip, int take);
    }
}
