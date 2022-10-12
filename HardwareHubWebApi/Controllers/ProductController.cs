using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepositorie _productRep;


        public ProductController(IProductRepositorie productRepositorie )
        {
            _productRep = productRepositorie;

        }

        [HttpGet]

        public async Task<ActionResult<List<ProductDto>>> GetAllProduct() {

            var products = await _productRep.GetAll();
            return Ok(products);

        }

        [HttpGet ("{Id:int}")]

        public async Task<ActionResult<ProductFullDto>> GetSingleProductById(int Id)
        {
            var product= await _productRep.GetProductById(Id);
            return Ok(product);
        }


        [HttpPut]
        public async Task SaveProduct(ProductFullDto productDto) {

           
            await _productRep.Save(productDto);
             
        }

        [HttpDelete ("{Id:int}")]
        public async Task DeleteProductById(int Id)
        {
            await _productRep.DeleteById(Id);
        }


        //[HttpGet("{Category:int}")]

        //public async Task<ActionResult<List<ProductDto>>> GetProductByCategory(int category)
        //{
        //    var products = _productRep.GetProductsByCategory(category);
        //    return Ok(products);
        //}
    }
}
