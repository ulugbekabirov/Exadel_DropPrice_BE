using BL.Interfaces;
using BL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api")]
    [Authorize]
    public class HintsController : ControllerBase
    {
        private readonly IHintsService _searchService;

        public HintsController(IHintsService service)
        {
            _searchService = service;
        }

        [HttpGet("hints")]
        public async Task<IActionResult> Hints(string subString, SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _searchService.HintsAsync(subString, specifiedAmountModel));
        }
    }
}
