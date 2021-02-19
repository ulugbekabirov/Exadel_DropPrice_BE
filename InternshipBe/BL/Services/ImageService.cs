using AutoMapper;
using BL.DTO;
using BL.Interfaces;
using DAL.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<ImageDTO> RetrieveImageByIdAsync(int imageId)
        {
            var image = await _imageRepository.GetByIdAsync(imageId);

            var imageDTO = _mapper.Map<ImageDTO>(image);
            
            var extension = Path.GetExtension(image.Name).Replace(".", "");
            imageDTO.ContentType = $"image/{extension}";
            
            return imageDTO;
        }
    }
}
