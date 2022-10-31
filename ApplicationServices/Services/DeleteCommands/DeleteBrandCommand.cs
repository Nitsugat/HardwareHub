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
    public class DeleteBrandCommand:IRequest<Response<int>>
    {
        public int BrandId { get; set; }
    }

    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand ,Response<int>>
    {

        private readonly IRepositorie<Brands> _rep;

        public DeleteBrandCommandHandler(IRepositorie<Brands> rep)
        {
            _rep = rep;
        }


        public async Task<Response<int>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
             var brand = await  _rep.GetByIdAsync(request.BrandId);
             var data = brand;
            if (brand == null)
                throw new Exception("La marca que desea eliminar no existe o hubo un error al eliminarla");

        await _rep.DeleteAsync(brand);

            return new Response<int>(data.BrandId);
        }
    }
}
