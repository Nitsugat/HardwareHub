using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly ISupplierRepositorie _supplierRepositorie;

        public SupplierController(ISupplierRepositorie supplierRepositorie)
        {
            _supplierRepositorie = supplierRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierDto>>> GetAllSuppliers()
        {
        
         var suppliers = await this._supplierRepositorie.GetAll();
            return Ok(suppliers);

        
        }


        [HttpPut]
        public async Task SaveSupplier(SupplierDto supplierDto) {

           await  _supplierRepositorie.Save(supplierDto);
        
        }

        [HttpDelete ("{id:int}")]

        public async Task DeleteSupplier(int id)
        {
            await _supplierRepositorie.Delete(id);
        }
        

     

    }
}
