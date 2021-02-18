using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IImageService
    {
        Task AddImageToVendor(IFormFile file, int vendorId);
    }
}
