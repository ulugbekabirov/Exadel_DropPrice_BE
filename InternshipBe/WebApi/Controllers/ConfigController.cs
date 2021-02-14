using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;
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

        [HttpGet("configs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetConfigs()
        {
            return Ok(await _configService.GetConfigs());
        }

        [HttpPut("changeConfigs/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeConfigs(int id, [FromBody] ConfigViewModel configModel)
        {
            configModel.Id = id;

            return Ok(await _configService.ChangeConfigAsync(configModel));
        }
    }
}
