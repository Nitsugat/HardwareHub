using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.UpdateCommands.ProductUpdate
{
    public class ProductUpdateCommand:IRequest<Response<int>>
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int BrandId { get; set; }
        public string? ImgProduct { get; set; }
        public int? HardwareCategoryId { get; set; }
        public int SupplierId { get; set; }
        public string? Description { get; set; }


    }

    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Response<int>>
    {

        private readonly IRepositorie<Product> _rep;

        public ProductUpdateCommandHandler(IRepositorie<Product> rep)
        {
            _rep = rep;
        }

        public async Task<Response<int>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {

            var product = await _rep.GetByIdAsync(request.ProductId);
            var data = product;

            if (product == null)
            {
                return new Response<int>($"No se pudo modificar el producto con el id {product.ProductId} por que no existe o contiene valores nulos");
            }

            product.ProductName = request.ProductName;
            product.SupplierId = request.SupplierId;
            product.BrandId = request.BrandId;
            product.HardwareCategoryId = request.HardwareCategoryId;
            product.Description = request.Description;
            product.ImgProduct = request.ImgProduct;


             await _rep.UpdateAsync(product);
            

            return new Response<int>(data.ProductId,message:$"Se modificó correctamente el producto con el id {data.ProductId}");
        }
    }
}
