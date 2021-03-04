using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountValidationRepository
    {
        Task CheckDiscountStartDateAsync(int id);
    }
}
