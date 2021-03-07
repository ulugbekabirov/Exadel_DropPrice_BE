using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IValidator<TEntity> where TEntity : class
    {
        Task ValidateAsync(TEntity entity);
    }
}
