using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        public ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("tags")]
        public IActionResult GetTags(int skip, int take)
        {
            return Ok(_tagService.GetSpecifiedTags(skip, take));
        }

    }
}
