using ApplicationServices.Services.CreateCommand.ProductCreateCommand;
using ApplicationServices.Services.DeleteCommands;
using ApplicationServices.Services.Querys.ProductsQueries;
using ApplicationServices.Services.UpdateCommands.ProductUpdate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHubWebApi.Controllers
{
    [ApiVersion("1.0")]
    public class ProductController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> SaveNewProduct(ProductCreateCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await Mediator.Send(new GetAllProductsCommand { }));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetProductById(int id , GetProductByIdCommand command)
        {
            if (id != command.ProductId)
            {
                return  BadRequest("Error al encontrar la entidad con el Id proveeido");
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id, DeleteProductCommand command)
        {
            if (id != command.id)
            {
                return BadRequest("Error al eliminar el producto, el id proveeido no coincide con ningun producto");
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id , ProductUpdateCommand command)
        {
            if (command.ProductId != id)
            {
                return BadRequest("Error en los id proveeidos, no se encontró el producto que desea modificar");
            }
           return  Ok(await Mediator.Send(command));
        }

    }
}
