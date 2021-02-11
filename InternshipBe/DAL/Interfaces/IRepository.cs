using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task CreateAsync(TEntity item);

        IQueryable<TEntity> GetSpecifiedAmount(int skip, int take);

        Task SaveChangesAsync();

        GeoCoordinate GetLocation(double officeLatitude, double officeLongitude, double latittude = 0, double longitude = 0);

        Task<IDbContextTransaction> BeginTrancation();
    }
}
