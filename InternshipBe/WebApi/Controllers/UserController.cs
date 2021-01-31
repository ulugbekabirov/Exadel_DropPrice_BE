using BL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(await _service.GetUserInfoAsync(await _userManager.FindByNameAsync(User.Identity.Name)));
        }
    }
}
