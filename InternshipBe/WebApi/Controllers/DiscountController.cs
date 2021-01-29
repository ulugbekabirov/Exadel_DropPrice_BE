using BL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly UserManager<User> _userManager;

        public DiscountController(IDiscountService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("getDiscounts")]
        
        public async Task<IActionResult> GetUserInfo(int skip, int take, double latitude,  double longitude)
        {
            return Ok(_service.GetClosestDiscounts(skip, take, latitude, longitude, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
    }
}
