using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IVendorRepository _vendorRepository;

        public ImageService(IImageRepository imageRepository, IVendorRepository vendorRepository)
        {
            _imageRepository = imageRepository;
            _vendorRepository = vendorRepository;
        }

    }
}
