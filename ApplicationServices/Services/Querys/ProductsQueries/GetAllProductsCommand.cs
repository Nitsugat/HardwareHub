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
    public class GetAllProductsCommand : IRequest<Response<List<ProductDto>>>
    {
    }
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, Response<List<ProductDto>>>
    {
        private readonly IRepositorie<Product> _rep;

        public GetAllProductsCommandHandler(IRepositorie<Product> rep)
        {
            _rep = rep;
        }

        public async Task<Response<List<ProductDto>>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {



            var products = await _rep.ListAsync();

            if (products == null)
            {
                return new Response<List<ProductDto>>(message:$"No se encontraron productos, inserte productos nuevos para poder verlos");
            }

            List<ProductDto> productsDto = new();

            foreach (var product in products)
            {
                ProductDto productDto = new();
                productDto.ProductId = product.ProductId;
                    productDto.ProductName = product.ProductName;
                    productDto.Supplier = product.SupplierId;
                    productDto.HardwareCategory = product.HardwareCategoryId;
                    productDto.BrandId = product.BrandId;
                    productDto.Description = product.Description;
                    productDto.Img = product.ImgProduct;

                productsDto.Add(productDto);
            }




            return new Response<List<ProductDto>>(productsDto);
        }
    }
}
