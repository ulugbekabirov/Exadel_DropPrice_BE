using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountValidation
    {
        Task CheckDiscountValidationAsync(int id);
    }
}
