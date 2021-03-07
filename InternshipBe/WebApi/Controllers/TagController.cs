using BL.Interfaces;
using BL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{   
    /// <summary>
    /// Contains actions for working with tags
    /// </summary>
    [Route("api/")]
    [Authorize]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        ///  Action to get all tags
        /// </summary>
        /// <param name="specifiedAmountModel">Model to specify tags amount</param>
        /// <returns>Returns all tags</returns>
        [HttpGet("tags")]
        public async Task<IActionResult> GetTags(SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _tagService.GetSpecifiedAmountAsync(specifiedAmountModel));
        }
    }
}
