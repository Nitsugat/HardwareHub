using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.CreateCommand.ProductCreateCommand
{
    public class ProductCreateCommand : IRequest<Response<int>>
    {
        public string? ProductName { get; set; }
        public int BrandId { get; set; }
        public int HardwareCategoryId { get; set; }
        public int SupplierId { get; set; }
        public string? Description { get; set; }
        public string? IMG { get; set; }
    }

    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Response<int>>
    {
        private readonly IRepositorie<Product> _rep;
        private readonly IRepositorie<Stock> _stockRep;

        public ProductCreateCommandHandler(IRepositorie<Product> rep, IRepositorie<Stock> stockRep)
        {
            _rep = rep;
            _stockRep = stockRep;
        }
        public async Task<Response<int>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {

           

            Product product = new()
            {
                ProductName = request.ProductName,
                SupplierId = request.SupplierId,
                BrandId = request.BrandId,
                HardwareCategoryId = request.HardwareCategoryId,
                Description = request.Description,
                ImgProduct = request.IMG

                
            };

            var data = await _rep.AddAsync(product);


            Stock stock = new()
            {
                ProductId = data.ProductId,
                Quantitly = 0,
                PublicPrice = 0,
                State=false
            

            };
                
                
                await _stockRep.AddAsync(stock);

            

            return new Response<int>(data.ProductId ,message:"Se agregó el nuevo producto exitosamente");
        
        }
           
    }
    
        
}
