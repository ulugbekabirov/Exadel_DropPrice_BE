using BL.Interfaces;
using BL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.Filters;
using Shared.ViewModels;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    /// <summary>
    /// Сontains actions for working with discounts
    /// </summary>
    [Route("api/discounts")]
    [Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ITicketService _ticketService;
        private readonly IHangfireService _hangfireService;
        private readonly UserManager<User> _userManager;

        public DiscountController(IDiscountService discountService, ITicketService ticketService, IHangfireService hangfireService, UserManager<User> userManager)
        {
            _discountService = discountService;
            _ticketService = ticketService;
            _hangfireService = hangfireService;
            _userManager = userManager;
        }

        /// <summary>
        /// Action to get discounts
        /// </summary>
        /// <param name="sortModel">Model to get specified amount of closest and sorted discounts</param>
        /// <returns>Returns the discounts</returns>
        [HttpGet]
        public async Task<IActionResult> GetDiscounts(SortModel sortModel)
        {
            return Ok(await _discountService.GetDiscountsAsync(sortModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        /// Action to get discount by ID
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <param name="locationModel">Model to get discount</param>
        /// <returns>Returns discount</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id, LocationModel locationModel)
        {
            return Ok(await _discountService.GetDiscountByIdAsync(id, locationModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        /// Action for searching a discount
        /// </summary>
        /// <param name="searchmodel">Model for search discounts</param>
        /// <returns>Returns found discounts</returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchDiscounts(SearchModel searchmodel)
        {
            return Ok(await _discountService.SearchDiscountsAsync(searchmodel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        /// Action for ordering a discount
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <returns>Returns the ticket</returns>
        [HttpGet("{id}/createTicket")]
        public async Task<IActionResult> CreateTicket(int id)
        {
            return Ok(await _ticketService.GetOrCreateTicketAsync(id, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        /// Action to add a discount to favorites
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <returns>Returns conservation status</returns>
        [HttpPut("{id}/save")]
        public async Task<IActionResult> SaveDiscount(int id)
        {
            return Ok(await _discountService.SaveOrUnsaveDisocuntAsync(id, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        /// Action to assess the discount
        /// </summary>
        /// <param name="id">Dicount ID</param>
        /// <param name="assessmentViewModel">Model to assess discount</param>
        /// <returns>Returns assessment of discount</returns>
        [HttpPut("{id}/assess")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> UpdateUserAssessmentForDiscount(int id, [FromBody] AssessmentViewModel assessmentViewModel)
        {
            return Ok(await _discountService.UpdateUserAssessmentForDiscountAsync(id, assessmentViewModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        /// <summary>
        /// Action to archive or unarchive discount
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <returns>Returns activity status</returns>
        [HttpPut("{id}/archive")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> ArchiveOrUnarchiveDiscount(int id)
        {
            return Ok(await _discountService.ArchiveOrUnarchiveDiscountAsync(id));
        }

        /// <summary>
        /// Action to create a new discount in the database. 
        /// </summary>
        /// <param name="discountViewModel">Model to create a new discount</param>
        /// <returns>Returns the created discount</returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountViewModel discountViewModel)
        {
            return Ok(await _discountService.CreateDiscountWithPointOfSalesAndTagsAsync(discountViewModel));
        }

        /// <summary>
        /// Action to begin edit discount job
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <returns>Returns message of begin edit</returns>
        [HttpPut("{id}/beginEdit")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> BeginEditJob(int id)
        {
            return Content(await _hangfireService.BeginEditDiscountJobAsync(id));
        }

        /// <summary>
        /// Action to end edit discount job
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <returns>Returns message of edit job</returns>
        [HttpDelete("{id}/endEdit")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> EndEditJob(int id)
        {
            return Content(await _hangfireService.EndEditDiscountJobAsync(id));
        }

        /// <summary>
        /// Action to update a discount in the database. 
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <param name="discountViewModel">Model to update a discount</param>
        /// <returns>Returns updated discount</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] DiscountViewModel discountViewModel)
        {
            discountViewModel.DiscountId = id;
            return Ok(await _discountService.UpdateDiscountAsync(discountViewModel));
        }

        /// <summary>
        /// Action for searching stats of discounts
        /// </summary>
        /// <param name="adminSearchModel">Model to get statis of discounts</param>
        /// <returns>Returns the discounts</returns>
        [HttpGet("stats/search")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchDiscountsForStatistics(AdminSearchModel adminSearchModel)
        {
            return Ok(await _discountService.SearchDiscountsForStatisticsAsync(adminSearchModel));
        }

        /// <summary>
        /// Action to get discount pointOfSales
        /// </summary>
        /// <param name="id">Discount ID</param>
        /// <returns>Returns pointOfSales</returns>
        [HttpGet("{id}/pointOfSales")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> PointOfSalesAsync(int id)
        {
            return Ok(await _discountService.GetPointOfSalesAsync(id));
        }

        /// <summary>
        /// Action to get hints for search
        /// </summary>
        /// <param name="subSearchQuery">Search string</param>
        /// <param name="specifiedAmountModel">Model to get specified amount of discount</param>
        /// <returns>Returns discount names</returns>
        [HttpGet("search/hints")]
        public async Task<IActionResult> GetSearchHints(string subSearchQuery, SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _discountService.GetSearchHintsAsync(subSearchQuery, specifiedAmountModel));
        }
    }
}
