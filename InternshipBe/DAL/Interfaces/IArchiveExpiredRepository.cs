using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IArchiveExpiredRepository
    {
        Task ArchiveExpiredDiscountAsync();
    }
}
