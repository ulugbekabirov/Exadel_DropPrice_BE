using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/towns")]
    [ApiController]
    [Authorize]
    public class TownController : ControllerBase
    {
        private readonly ITownService _townService;
        public TownController(ITownService service) 
        {
            _townService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTowns()
        {
            return Ok(await _townService.GetTownsAsync());
        }
    }
}
