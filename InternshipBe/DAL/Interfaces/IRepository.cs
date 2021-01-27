using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);

        void Create(TEntity item);

        IQueryable<TEntity> GetSpecifiedAmount(int skip, int take);
    }
}
