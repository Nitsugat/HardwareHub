using ApplicationServices.Services.CreateCommand.SupplierCreateCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareHubWebApi.Controllers
{

    [ApiVersion("1.0")]
    public class SupplierController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddSupplier(SupplierCreateCommand command)
        {

            return Ok( await Mediator.Send(command));
        }
    }
}
