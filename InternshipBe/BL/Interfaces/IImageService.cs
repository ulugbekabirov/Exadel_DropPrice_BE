using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IImageService
    {
        Task<string> GetImageByIdAsync(int imageId);
    }
}
