using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.DeleteCommands
{
    public class DeleteProductCommand:IRequest<Response<int>>
    {
        public int id { get; set; }
    }

    public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand,Response<int>>
    {
        private readonly IRepositorie<Product> _rep;

        public DeleteProductCommandHandler(IRepositorie<Product> rep)
        {
            _rep = rep;
        }

       
        public async Task<Response<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           
            var product =  await _rep.GetByIdAsync(request.id);
            if (product == null)
            {
                return new Response<int>($"No se encontro la entidad con id {request.id}");
            }

            var data = product;
            await _rep.DeleteAsync(product);

            return new Response<int>(data.ProductId, message:$"Se eliminó correctamente el producto con el id {request.id} ");
        }
    }

}
