using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountValidatior
    {
        Task CheckDiscountValidationAsync(int id);
    }
}
