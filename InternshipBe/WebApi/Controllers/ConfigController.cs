using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.Filters;
using Shared.ViewModels;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// Contains actions for working with configs
    /// </summary>
    [Route("api/")]
    [Authorize]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;

        public ConfigController(IConfigService service)
        {
            _configService = service;
        }

        /// <summary>
        /// Action to get all configs 
        /// </summary>
        /// <returns>Returns all configs</returns>
        [HttpGet("configs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetConfigs()
        {
            return Ok(await _configService.GetConfigsAsync());
        }

        /// <summary>
        ///  Action to change configs by ID
        /// </summary>
        /// <param name="id">Config ID</param>
        /// <param name="configModel">Model to update config</param>
        /// <returns>Returns updated config</returns>
        [HttpPut("changeConfigs/{id}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> ChangeConfigs(int id, [FromBody] ConfigViewModel configModel)
        {
            configModel.Id = id;
            return Ok(await _configService.ChangeConfigAsync(configModel));
        }
    }
}
