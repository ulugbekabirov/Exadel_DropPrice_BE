using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{   
    /// <summary>
    /// Controller contains a method for display towns info
    /// </summary>
    [Route("api/towns")]
    [ApiController]
    [Authorize]
    public class TownController : ControllerBase
    {
        private readonly ITownService _townService;
        /// <summary>
        /// TownController constructor
        /// </summary>
        /// <param name="service"></param>
        public TownController(ITownService service) 
        {
            _townService = service;
        }
        /// <summary>
        /// Method for get all towns 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTowns()
        {
            return Ok(await _townService.GetTownsAsync());
        }
    }
}
