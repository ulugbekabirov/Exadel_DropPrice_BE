using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IImageService
    {
        Task<string> RetrieveImageByIdAsync(int imageId);
    }
}
