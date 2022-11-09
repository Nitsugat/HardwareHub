using ApplicationServices.DTOs.DTOSadmins;
using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.Querys.ProductsQueries
{
    public class GetProductByIdCommand: IRequest<Response<ProductDto>>
    {
       public int ProductId { get; set; }
    }


    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand ,Response<ProductDto>>
    {
        private readonly IRepositorie<Product> _rep;

        public GetProductByIdCommandHandler(IRepositorie<Product> rep )
        {
            _rep = rep;
            
        }

        public async Task<Response<ProductDto>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
           var product = await  _rep.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                return new Response<ProductDto>(message:$"La entidad con el id {request.ProductId} no puede ser devuelta por que no existe o contiene valores nulos");
            }

            ProductDto productDto = new()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                HardwareCategory = product.HardwareCategoryId,
                Supplier = product.SupplierId,
                Img = product.ImgProduct,
                Description = product.Description,

            };

            return new Response<ProductDto>(productDto);
        }
    }
}
