using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/user")]
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

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(await _userService.GetUserInfoAsync(await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpGet("saved")]
        public async Task<IActionResult> GetUserSavedDiscounts(LocationModel locationModel)
        {
            return Ok(await _userService.GetUserDiscountsAsync(locationModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        
        [HttpGet("tickets")]
        public async Task<IActionResult> GetUserTickets(SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _userService.GetUserTicketsAsync(await _userManager.FindByNameAsync(User.Identity.Name), specifiedAmountModel));
        }
    }
}
