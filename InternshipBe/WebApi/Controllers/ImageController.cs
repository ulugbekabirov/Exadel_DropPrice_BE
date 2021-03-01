using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    /// <summary>
    /// Controller contains a method for display image
    /// </summary>
    [Route("api/images")]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        /// <summary>
        /// ImageController constructor
        /// </summary>
        /// <param name="imageService"></param>
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        /// <summary>
        /// Method for get image by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _imageService.RetrieveImageByIdAsync(id);
            return File(image.ImageData, image.ContentType);
        }
    }
}
