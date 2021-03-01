using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller contains a method for display point of sales
    /// </summary>
    [Route("api/pointOfSales")]
    [Authorize]
    public class PointOfSaleController : ControllerBase
    {
        private readonly IPointOfSaleService _pointOfSaleService;
        /// <summary>
        /// PointOfSaleController constructor
        /// </summary>
        /// <param name="pointOfSaleService"></param>
        public PointOfSaleController(IPointOfSaleService pointOfSaleService)
        {
            _pointOfSaleService = pointOfSaleService;
        }
        /// <summary>
        /// Method for get all points of sales
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPointOfSales()
        {
            return Ok(await _pointOfSaleService.GetPointOfSalesAsync());
        }
    }
}
