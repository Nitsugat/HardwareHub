using ApplicationServices.Services.CreateCommand.HardwareCategories;
using ApplicationServices.Services.DeleteCommands;
using ApplicationServices.Services.Querys.HardwareCategorieQueries;
using ApplicationServices.Services.UpdateCommands.HardwareCategoryUpdate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHubWebApi.Controllers
{
    [ApiVersion("1.0")]
    public class HardwareCategorieController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateHardwareCategory(HardwareCategorieCreateCommand command)
        {

           return Ok(await Mediator.Send(command));
        }

        [HttpDelete("Id")]

        public async Task<IActionResult> DeleteHardwareCategory(int Id ,HardwareCategorieDeleteCommand command)
        {
            if (Id != command.CategorieId )
            {
                throw new Exception("Hubo un error al procesar la solicitud, el Id proveeido no se pudo encontrar en el sistema.");
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]

        public async Task<IActionResult> GetAllCategories( )
        {
            return Ok( await Mediator.Send(new HardwareCategorieGetAllCommand
            {

            }));
        }

        [HttpPut ("Id")]

        public async Task<IActionResult> UpdateCategorie(int Id,UpdateHardwareCategorieCommand command)
        {
            if (Id != command.Id)
            {
                throw new Exception("Hubo un error, no se pudo realizar la modificación, id diferentes");
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
