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
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<User> _userManager;

        public TicketController(ITicketService service, UserManager<User> userManager)
        {
            _ticketService = service;
            _userManager = userManager;
        }

        [HttpGet("ticket")]
        public async Task<IActionResult> GetTicketForUser(int discountId)
        {
            return Ok(_ticketService.GetOrCreateTicket(discountId, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
    }
}
