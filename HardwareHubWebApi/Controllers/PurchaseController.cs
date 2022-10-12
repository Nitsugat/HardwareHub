using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.Infrastructure.Repositories;
using HardwareStore.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepositorie _purchaseRep;
        public PurchaseController(IPurchaseRepositorie purchaseRep)
        {
            _purchaseRep = purchaseRep;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchaseDto>>> GetAllPurchases() {

            var purchases = await _purchaseRep.GetAll();
            return Ok(purchases);
        
        }

        [HttpPost]
        public async Task SavePurchase(PurchaseDto purchase) {


           await  _purchaseRep.Save(purchase);
           
        
        }

        [HttpPut]
        public async Task AddDetails(PurchaseDetailDto detail)
        {
            await _purchaseRep.AddDetail(detail);

        }

    }
}
