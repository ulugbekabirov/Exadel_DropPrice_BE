using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/vendors")]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendors()
        {
            return Ok(await _vendorService.GetVendorsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorById(int id)
        {
            return Ok(await _vendorService.GetVendorByIdAsync(id));
        }
    }
}
