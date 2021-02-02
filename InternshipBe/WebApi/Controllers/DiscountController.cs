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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly UserManager<User> _userManager;

        public DiscountController(IDiscountService service, UserManager<User> userManager)
        {
            _discountService = service;
            _userManager = userManager;
        }

        [HttpGet("discounts")]
        public async Task<IActionResult> GetDiscounts(SortModel sortModel)
        {
            return Ok(await _discountService.GetClosestAsync(sortModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
    }
}
