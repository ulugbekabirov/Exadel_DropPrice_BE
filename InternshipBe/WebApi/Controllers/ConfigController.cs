using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/")]
    [Authorize]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;
        private readonly UserManager<User> _userManager;

        public ConfigController(IConfigService service, UserManager<User> userManager)
        {
            _configService = service;
            _userManager = userManager;
        }

        [HttpGet("config")]
        public IActionResult GetRadius()
        {
            return Ok(_configService.GetConfig().RadiusInMeters);
        }


        [HttpPost("config")]
        public async Task<IActionResult> ChangeRadius([FromBody] ConfigModel newradius)
        {
            return Ok(await _configService.ChangeConfig(newradius));
        }
    }
}
