using BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/pointOfSales")]
    [Authorize]
    public class PointOfSaleController : ControllerBase
    {
        private readonly IPointOfSaleService _pointOfSaleService;

        public PointOfSaleController(IPointOfSaleService pointOfSaleService)
        {
            _pointOfSaleService = pointOfSaleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPointOfSales()
        {
            return Ok(await _pointOfSaleService.GetPointOfSalesAsync());
        }
    }
}
