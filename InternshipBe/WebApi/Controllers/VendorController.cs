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
    /// Controller contains a methods for display Vendors info
    /// </summary>
    [Route("api/vendors")]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// VendorController constructor
        /// </summary>
        /// <param name="vendorService"></param>
        /// <param name="userManager"></param>
        public VendorController(IVendorService vendorService, UserManager<User> userManager)
        {
            _vendorService = vendorService;
            _userManager = userManager;
        }
        /// <summary>
        /// Method of get all Vendors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetVendors()
        {
            return Ok(await _vendorService.GetVendorsAsync());
        }
        /// <summary>
        /// Method of get Vendors by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorById(int id)
        {
            return Ok(await _vendorService.GetVendorByIdAsync(id));
        }
        /// <summary>
        /// Method of get discounts by Vendor id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sortModel"></param>
        /// <returns></returns>
        [HttpGet("{id}/discounts")]
        public async Task<IActionResult> GetVendorDiscounts(int id, SortModel sortModel)
        {
            return Ok(await _vendorService.GetVendorDiscountsAsync(id, sortModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        /// Method for create Vendor 
        /// </summary>
        /// <param name="vendorViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> CreateVendor([FromBody] VendorViewModel vendorViewModel)
        {
            return Ok(await _vendorService.CreateVendorAsync(vendorViewModel));
        }
        /// <summary>
        /// Method for update Vendor by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vendorViewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody]VendorViewModel vendorViewModel)
        {
            vendorViewModel.VendorId = id;
            return Ok(await _vendorService.UpdateVendorAsync(vendorViewModel));
        }
        /// <summary>
        /// Method for search Vendors 
        /// </summary>
        /// <param name="searchmodel"></param>
        /// <returns></returns>
        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchVendors(AdminSearchModel searchmodel)
        {
            return Ok(await _vendorService.SearchVendorsAsync(searchmodel));
        }
        /// <summary>
        /// Method for add image by id and file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("{id}/image")]
        [Authorize(Roles ="Admin,Moderator")]
        public async Task<IActionResult> AddImage(int id, IFormFile file)
        {
            return Ok(await _vendorService.AddImageToVendorAsync(file, id));
        }
        /// <summary>
        ///  Method for get point of sales by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/pointOfSales")]
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> GetVendorPointOfSales(int id)
        {
            return Ok(await _vendorService.GetVendorPointOfSalesAsync(id));
        }
    }
}
