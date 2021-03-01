using BL.Interfaces;
using BL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{   
    /// <summary>
    /// Controller contains a method for display tag info
    /// </summary>
    [Route("api/")]
    [Authorize]
    public class TagController : ControllerBase
    {
        public ITagService _tagService;
        /// <summary>
        /// TagController constructor
        /// </summary>
        /// <param name="tagService"></param>
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        /// <summary>
        ///  Method for get all tags
        /// </summary>
        /// <param name="specifiedAmountModel"></param>
        /// <returns></returns>
        [HttpGet("tags")]
        public async Task<IActionResult> GetTags(SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _tagService.GetSpecifiedAmountAsync(specifiedAmountModel));
        }
    }
}
