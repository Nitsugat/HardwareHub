using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockRepositorie _stockRep;

        public StockController(StockRepositorie stockRep)
        {
            _stockRep = stockRep;
        }


        [HttpGet]

        public async Task<ActionResult<List<StockDto>>> GetAllStock() {

            var stocks = _stockRep.GetAllStock();
            return Ok(stocks);
        
        }
    }
}
