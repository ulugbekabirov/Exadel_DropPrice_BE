using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDapperRepository
    {
        Task ArchiveInvalidDiscount();
    }
}
