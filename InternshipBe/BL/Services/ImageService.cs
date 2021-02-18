using BL.Interfaces;
using DAL.Interfaces;
using System;
using System.IO;
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

        public async Task<string> RetrieveImageByIdAsync(int imageId)
        {
            var image = await _imageRepository.GetByIdAsync(imageId);
            var imageBase64Data = Convert.ToBase64String(image.ImageData);
            var extension = Path.GetExtension(image.Name).Replace(".", "");
            var imageDataURL = string.Format("data:image/{0};base64,{1}", extension, imageBase64Data);
            return imageDataURL;
        }
    }
}
