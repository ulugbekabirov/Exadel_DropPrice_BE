using BL.Interfaces;
using DAL.Interfaces;

namespace BL.Services
{
    public class ImageService: IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        

    }
}
