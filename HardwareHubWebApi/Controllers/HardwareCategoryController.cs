using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.Infrastructure.Repositories;
using HardwareStore.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareCategoryController : ControllerBase
    {
        private readonly IHardwareCategoryRepositorie _hardwareRep;

        public HardwareCategoryController(IHardwareCategoryRepositorie hardwareRep)
        {
            _hardwareRep = hardwareRep;
        }

        [HttpGet]
        public async Task<ActionResult<List<HardwareCategoryDto>>> GetAllCategories(){

            var categories = await _hardwareRep.GetAll();
            return Ok(categories);

        }

        [HttpPut]
        public async Task SaveCategory(HardwareCategoryDto categoryDto) {

            await _hardwareRep.Save(categoryDto);
        
        }
    }
}
