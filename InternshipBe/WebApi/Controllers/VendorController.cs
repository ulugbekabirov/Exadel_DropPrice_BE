using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.Filters;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    /// <summary>
    /// Contains actions for working with vendors
    /// </summary>
    [Route("api/vendors")]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly UserManager<User> _userManager;

        public VendorController(IVendorService vendorService, UserManager<User> userManager)
        {
            _vendorService = vendorService;
            _userManager = userManager;
        }

        /// <summary>
        /// Action to get all vendors
        /// </summary>
        /// <returns>Returns all vendors</returns>
        [HttpGet]
        public async Task<IActionResult> GetVendors()
        {
            return Ok(await _vendorService.GetVendorsAsync());
        }

        /// <summary>
        /// Action to get vendor by ID
        /// </summary>
        /// <param name="id">Vendor ID</param>
        /// <returns>Returns vendor by ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorById(int id)
        {
            return Ok(await _vendorService.GetVendorByIdAsync(id));
        }

        /// <summary>
        /// Action to get discounts of vendor by ID 
        /// </summary>
        /// <param name="id">Vendor ID</param>
        /// <param name="sortModel">Model to sort the discounts</param>
        /// <returns>Returns discounts of vendor</returns>
        [HttpGet("{id}/discounts")]
        public async Task<IActionResult> GetVendorDiscounts(int id, SortModel sortModel)
        {
            return Ok(await _vendorService.GetVendorDiscountsAsync(id, sortModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        /// Action to create a new vendor
        /// </summary>
        /// <param name="vendorViewModel">Model to create a new vendor</param>
        /// <returns>Returns created vendor</returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> CreateVendor([FromBody] VendorViewModel vendorViewModel)
        {
            return Ok(await _vendorService.CreateVendorAsync(vendorViewModel));
        }

        /// <summary>
        /// Action to update vendor by id
        /// </summary>
        /// <param name="id">Vendor ID</param>
        /// <param name="vendorViewModel">Model to update a vendor</param>
        /// <returns>Returns updated vendor</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody]VendorViewModel vendorViewModel)
        {
            vendorViewModel.VendorId = id;
            return Ok(await _vendorService.UpdateVendorAsync(vendorViewModel));
        }

        /// <summary>
        /// Action to search vendors 
        /// </summary>
        /// <param name="searchmodel">Model for seacrhing vendors</param>
        /// <returns>Returns vendors</returns>
        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchVendors(AdminSearchModel searchmodel)
        {
            return Ok(await _vendorService.SearchVendorsAsync(searchmodel));
        }

        /// <summary>
        /// Action for adding image to vendor
        /// </summary>
        /// <param name="id">Vendor ID</param>
        /// <param name="file">Image supports (".jpeg", ".png", ".jpg") extensions</param>
        /// <returns>Returns vendor with image</returns>
        [HttpPost("{id}/image")]
        [Authorize(Roles ="Admin,Moderator")]
        public async Task<IActionResult> AddImage(int id, IFormFile file)
        {
            return Ok(await _vendorService.AddImageToVendorAsync(file, id));
        }

        /// <summary>
        ///  Action to get points of sales of vendor 
        /// </summary>
        /// <param name="id">Vendor ID</param>
        /// <returns>Returns points of sale</returns>
        [HttpGet("{id}/pointOfSales")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> GetVendorPointOfSales(int id)
        {
            return Ok(await _vendorService.GetVendorPointOfSalesAsync(id));
        }
    }
}
