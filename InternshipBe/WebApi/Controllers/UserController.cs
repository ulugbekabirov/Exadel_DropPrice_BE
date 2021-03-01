using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{   
    /// <summary>
    /// Contains actions for working with user
    /// </summary>
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

        /// <summary>
        /// Action to get user info
        /// </summary>
        /// <returns>Returns user info</returns>
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(await _userService.GetUserInfoAsync(await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        ///  Action to get saved discounts of user
        /// </summary>
        /// <param name="locationModel">Model to get saved discounts</param>
        /// <returns>Returns saved discounts</returns>
        [HttpGet("saved")]
        public async Task<IActionResult> GetUserSavedDiscounts(LocationModel locationModel)
        {
            return Ok(await _userService.GetUserSavedDiscountsAsync(locationModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        ///  Action to get tickets of user
        /// </summary>
        /// <param name="specifiedAmountModel">Model to spicify tickets amount</param>
        /// <returns>Returns tickets</returns>
        [HttpGet("tickets")]
        public async Task<IActionResult> GetUserTickets(SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _userService.GetUserTicketsAsync(await _userManager.FindByNameAsync(User.Identity.Name), specifiedAmountModel));
        }
    }
}
