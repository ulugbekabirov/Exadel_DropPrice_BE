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

        public ConfigController(IConfigService service)
        {
            _configService = service;
        }

        [HttpGet("config")]
        public IActionResult GetRadius()
        {
            return Ok(_configService.GetConfig());
        }


        [HttpPut("config")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRadius([FromBody] ConfigModel newConfigs)
        {
            return Ok(await _configService.ChangeConfigAsync(newConfigs));
        }
    }
}
