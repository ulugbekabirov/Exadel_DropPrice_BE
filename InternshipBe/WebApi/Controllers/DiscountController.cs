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
    /// Controller contains a method for display discounts info
    /// </summary>
    [Route("api/discounts")]
    [Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ITicketService _ticketService;
        private readonly IHangfireService _hangfireService;
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// DiscountController constructor
        /// </summary>
        /// <param name="discountService"></param>
        /// <param name="ticketService"></param>
        /// <param name="userManager"></param>
        public DiscountController(IDiscountService discountService, ITicketService ticketService, UserManager<User> userManager)
        {
            _discountService = discountService;
            _ticketService = ticketService;
            _hangfireService = hangfireService;
            _userManager = userManager;
        }
        /// <summary>
        /// Method for get all Discounts
        /// </summary>
        /// <param name="sortModel"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDiscounts(SortModel sortModel)
        {
            return Ok(await _discountService.GetDiscountsAsync(sortModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        /// Method for get discounts by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locationModel"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id, LocationModel locationModel)
        {
            return Ok(await _discountService.GetDiscountByIdAsync(id, locationModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        /// Method for search Discounts
        /// </summary>
        /// <param name="searchmodel"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchDiscounts(SearchModel searchmodel)
        {
            return Ok(await _discountService.SearchDiscountsAsync(searchmodel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        /// Method for create ticket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/createTicket")]
        public async Task<IActionResult> CreateTicket(int id)
        {
            return Ok(await _ticketService.GetOrCreateTicketAsync(id, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        /// Method for save ticket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/save")]
        public async Task<IActionResult> SaveDiscount(int id)
        {
            return Ok(await _discountService.SaveOrUnsaveDisocuntAsync(id, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        /// Method for update assess by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assessmentViewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}/assess")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> UpdateUserAssessmentForDiscount(int id, [FromBody] AssessmentViewModel assessmentViewModel)
        {
            return Ok(await _discountService.UpdateUserAssessmentForDiscountAsync(id, assessmentViewModel, await _userManager.FindByNameAsync(User.Identity.Name)));
        }
        /// <summary>
        /// Method for archive Discount by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/archive")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> ArchiveOrUnarchiveDiscount(int id)
        {
            return Ok(await _discountService.ArchiveOrUnarchiveDiscountAsync(id));
        }
        /// <summary>
        /// Method for create Discount with point of sales and tags
        /// </summary>
        /// <param name="discountViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountViewModel discountViewModel)
        {
            return Ok(await _discountService.CreateDiscountWithPointOfSalesAndTagsAsync(discountViewModel));
        }
        /// <summary>
        /// Method for update Discount by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="discountViewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Moderator")]
        [ServiceFilter(typeof(ValidateModelFilterAttribute))]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] DiscountViewModel discountViewModel)
        {
            discountViewModel.DiscountId = id;
            return Ok(await _discountService.UpdateDiscountAsync(discountViewModel));
        }
        /// <summary>
        /// Method of  search discount for statistic
        /// </summary>
        /// <param name="adminSearchModel"></param>
        /// <returns></returns>
        [HttpGet("stats/search")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchDiscountsForStatistics(AdminSearchModel adminSearchModel)
        {
            return Ok(await _discountService.SearchDiscountsForStatisticsAsync(adminSearchModel));
        }
        /// <summary>
        /// Method of get point of sales by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/pointOfSales")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> PointOfSalesAsync(int id)
        {
            return Ok(await _discountService.GetPointOfSalesAsync(id));
        }
        /// <summary>
        /// Method for search Hints
        /// </summary>
        /// <param name="subSearchQuery"></param>
        /// <param name="specifiedAmountModel"></param>
        /// <returns></returns>
        [HttpGet("search/hints")]
        public async Task<IActionResult> GetSearchHints(string subSearchQuery, SpecifiedAmountModel specifiedAmountModel)
        {
            return Ok(await _discountService.GetSearchHintsAsync(subSearchQuery, specifiedAmountModel));
        }
    }
}
