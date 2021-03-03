using DAL.DataContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity item)
        {
            await _entities.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTrancation()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public Point GetLocation(double officeLatitude, double officeLongitude, double latittude = 0, double longitude = 0)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            if (latittude == 0 && longitude == 0)
            {
                return geometryFactory.CreatePoint(new Coordinate(officeLongitude, officeLatitude));
            }

            return geometryFactory.CreatePoint(new Coordinate(longitude, latittude));
        }

        public async Task<IEnumerable<TEntity>> GetSpecifiedAmountAsync(IQueryable<TEntity> entities, int skip, int take)
        {
            return await entities.Skip(skip).Take(take).AsNoTracking().ToListAsync();
        }

        public SortTypes GetSortType(string sortBy)
        {
            return (SortTypes)Enum.Parse(typeof(SortTypes), sortBy);
        }
    }
}
