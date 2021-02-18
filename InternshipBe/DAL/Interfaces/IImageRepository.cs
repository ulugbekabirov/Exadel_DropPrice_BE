using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> CreateAndReturnImageAsync(byte[] imageData, string filename);
    }
}
