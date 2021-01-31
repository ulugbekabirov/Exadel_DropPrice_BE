using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/")]
    [Authorize]
    public class TagController : ControllerBase
    {
        public ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("tags")]
        public async Task<IActionResult> GetTags(int skip, int take)
        {
            return Ok(await _tagService.GetSpecifiedAmountAsync(skip, take));
        }
    }
}
