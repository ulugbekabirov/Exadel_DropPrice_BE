using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// Contains actions for working with image
    /// </summary>
    [Route("api/images")]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        /// <summary>
        /// Action to get image by ID
        /// </summary>
        /// <param name="id">Image ID</param>
        /// <returns>Returns image</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _imageService.RetrieveImageByIdAsync(id);
            return File(image.ImageData, image.ContentType);
        }
    }
}
