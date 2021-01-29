using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetTowns()
        {
            return Ok(_service.GetTowns());
        }
    }
}
