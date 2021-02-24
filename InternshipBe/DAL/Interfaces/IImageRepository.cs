using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IImageRepository:IRepository<Image>
    {
        Task<Image> CreateAndReturnImageAsync(byte[] imageData, string filename);
    }
}
