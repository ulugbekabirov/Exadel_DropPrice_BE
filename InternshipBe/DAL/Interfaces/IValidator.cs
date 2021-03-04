using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IValidator<TEntity> where TEntity : class
    {
        Task ValidateAsync(TEntity entity);
    }
}
