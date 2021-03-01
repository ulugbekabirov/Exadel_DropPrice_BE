using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{   
    /// <summary>
    /// Contains actions for working with towns
    /// </summary>
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

        /// <summary>
        /// Action to get all towns 
        /// </summary>
        /// <returns>Returns all towns</returns>
        [HttpGet]
        public async Task<IActionResult> GetTowns()
        {
            return Ok(await _townService.GetTownsAsync());
        }
    }
}
