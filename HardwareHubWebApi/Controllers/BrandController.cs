using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers
{
    [Route("HardwareHub/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly IBrandsRepositorie _brandRep;
        public BrandController(IBrandsRepositorie brandRep)
        {
            _brandRep = brandRep;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands() {

            var brands = await _brandRep.GetAll();
            return Ok(brands);
        }

        [HttpPut]
        public async Task InsertBrand(BrandDto brandDto) {


            await _brandRep.Save(brandDto);
         
        
        }

        [HttpDelete ("{id}")]

        public async Task DeleteBrand(int id)
        {
            await _brandRep.Delete(id);
        }

        



        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateBrand(int Id, BrandDto brandDto) 

        //{
        //    if (Id != brandDto.BrandId) 
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //    }
        //    catch
        //    {

        //    }


        //    //return await IBrandRepositorie.Delete(BrandDto);

        //}




        
    }
}
