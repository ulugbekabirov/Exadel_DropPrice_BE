using DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        public async Task ValidateAsync(TEntity entity)
        {
            throw new ValidationException($"ValidationException of {entity.GetType()}");
        }
    }
}
