using BL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
