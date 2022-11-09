using ApplicationServices.Services.CreateCommand.BrandCommands;
using ApplicationServices.Services.DeleteCommands;
using ApplicationServices.Services.Querys.QuerysBrand;
using ApplicationServices.Services.UpdateCommands.Brand;
using ApplicationServices.Wrappers.Parameters;
using HardwareHub.core.Entities;
using HardwareHubWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using static ApplicationServices.Services.Querys.QuerysBrand.GetAllBrandsQuery;

namespace HardwareHub.WebApi.Controllers
{
    
    [ApiVersion("1.0")]
    public class BrandController : BaseController
    {
      

        [HttpGet()]
        public async Task<IActionResult> GetAllBrands([FromQuery] GetAllBrandsParameters filter)
        {

            return Ok(await Mediator.Send(new GetAllBrandsQuery 
            { 
            PageSize = filter.PageSize,
            BrandName = filter.BrandName,
            PageIndex=filter.PageIndex,
            
            }));
        }

        [HttpPost]
        public async Task<IActionResult> InsertBrand(CreateBrandCommand brandCommand) 
        {
            return Ok(await Mediator.Send(brandCommand));
        
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteBrand(DeleteBrandCommand brandcommand)
        {
            return Ok( await Mediator.Send(brandcommand));
        }





        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id ,UpdateBrandCommand command )
        {
            //if (id != command.BrandId)
            //{
            //    throw new Exception($"Hubo un error al encontrar la marca solicitada, intente nuevamente.");
            //}

            if (id != command.BrandId)
                return BadRequest("Error en los ID a modificar");
            return Ok(await Mediator.Send(command));
        }





    }
}
