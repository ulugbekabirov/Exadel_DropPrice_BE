using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.Filters;
using Shared.ViewModels;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller contains a methods for display config info
    /// </summary>
    [Route("api/")]
    [Authorize]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;
        /// <summary>
        /// ConfigController constructor
        /// </summary>
        /// <param name="service"></param>
        public ConfigController(IConfigService service)
        {
            _configService = service;
        }
        /// <summary>
        /// Method for get all configs 
        /// </summary>
        /// <returns></returns>
        [HttpGet("configs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetConfigs()
        {
            return Ok(await _configService.GetConfigsAsync());
        }
        /// <summary>
        ///  Method for change configs by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="configModel"></param>
        /// <returns></returns>
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
