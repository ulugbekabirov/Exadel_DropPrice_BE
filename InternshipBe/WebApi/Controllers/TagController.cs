using BL.Interfaces;
using BL.Models;
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
        public async Task<IActionResult> GetTags(SpecifiedAmountModel model)
        {
            return Ok(await _tagService.GetSpecifiedAmountAsync(model));
        }
    }
}
