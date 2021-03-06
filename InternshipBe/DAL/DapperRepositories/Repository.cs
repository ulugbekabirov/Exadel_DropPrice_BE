using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DapperRepositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    { 
        public Task<IDbContextTransaction> BeginTrancation()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Point GetLocation(double officeLatitude, double officeLongitude, double latittude = 0, double longitude = 0)
        {
            throw new NotImplementedException();
        }

        public SortTypes GetSortType(string sortBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetSpecifiedAmountAsync(IQueryable<TEntity> entities, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        Task<IDbContextTransaction> IRepository<TEntity>.BeginTrancation()
        {
            throw new NotImplementedException();
        }
    }
}
