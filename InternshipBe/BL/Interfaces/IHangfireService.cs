using BL.DTO;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IHangfireService
    {
        Task<DiscountJobDTO> BeginEditDiscountJobAsync(int discountId);

        void DeleteDiscountEditJob(int discountId);

        Task<string> EndEditDiscountJobAsync(int discountId);
    }
}
