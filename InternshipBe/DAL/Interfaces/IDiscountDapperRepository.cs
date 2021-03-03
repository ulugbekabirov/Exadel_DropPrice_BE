using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDiscountDapperRepository
    {
        Task ArchiveExpiredDiscountAsync();
    }
}
