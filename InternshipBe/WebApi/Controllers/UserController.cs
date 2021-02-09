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
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(await _userService.GetUserInfoAsync(await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpGet("user/tickets")]
        public async Task<IActionResult> GetUserTickets()
        {
            return Ok(await _userService.GetUserTicketsAsync(await _userManager.FindByNameAsync(User.Identity.Name)));
        }
    }
}
