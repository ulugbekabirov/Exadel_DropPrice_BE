using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountValidation
    {
        Task CheckDiscountStartDateAsync(int id);
    }
}
