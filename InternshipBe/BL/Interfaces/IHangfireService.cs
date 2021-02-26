using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IHangfireService
    {
        Task<string> BeginEditDiscountJobAsync(int discountId);

        void DeleteDiscountEditJob(int discountId);

        Task<string> EndEditDiscountJobAsync(int discountId);
    }
}
