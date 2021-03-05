using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountValidatior
    {
        Task ValidateDiscountAsync(int id);
    }
}
