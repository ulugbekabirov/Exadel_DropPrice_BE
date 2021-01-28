using BL.DTO;
using BL.Services;
using DAL.Entities;
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
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        private readonly UserManager<User> _userManager;

        public UserController(UserService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("getUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userDTO = _service.getUserInfo(user);
            return Ok(userDTO);
        }

    }
}
