using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<string> GetImageByIdAsync(int imageId)
        {
            var image = await _imageRepository.GetByIdAsync(imageId);
            var imageBase64Data = Convert.ToBase64String(image.ImageData);
            var imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            return imageDataURL;
        }
    }
}
