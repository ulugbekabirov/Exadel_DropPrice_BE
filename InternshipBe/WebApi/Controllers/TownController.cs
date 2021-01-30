using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class TownController : ControllerBase
    {
        private readonly ITownService _service;
        public TownController(ITownService service) 
        {
            _service = service;
        }

        [HttpGet("towns")]
        public async Task<IActionResult> GetTowns()
        {
            return Ok(await _service.GetTownsAsync());
        }
    }
}
