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
    /// Controller contains a methods for display user info, saved discounts and tickets
    /// </summary>
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// UserController constructor
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="userManager"></param>
        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        /// <summary>
        /// Method of get user info by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok(await _userService.GetUserInfoAsync(await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        ///  Method of get user saved discounts
        /// </summary>
        /// <param name="locationModel"></param>
        /// <returns></returns>
        [HttpGet("saved")]
        public async Task<IActionResult> GetUserSavedDiscounts(LocationModel locationModel)
        {
            return Ok(await _userService.GetUserSavedDiscountsAsync(locationModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        ///  Method of get user tickets
        /// </summary>
        /// <param name="specifiedAmountModel"></param>
        /// <returns></returns>
        [HttpGet("tickets")]
        public async Task<IActionResult> GetUserTickets(SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _userService.GetUserTicketsAsync(await _userManager.FindByNameAsync(User.Identity.Name), specifiedAmountModel));
        }
    }
}
