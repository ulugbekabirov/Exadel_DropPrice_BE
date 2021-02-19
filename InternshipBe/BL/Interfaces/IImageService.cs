using BL.DTO;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IImageService
    {
        Task<ImageDTO> RetrieveImageByIdAsync(int imageId);
    }
}
