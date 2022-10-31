using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using MediatR;
using HardwareHub.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.UpdateCommands.Brand
{
    public class UpdateBrandCommand:IRequest<Response<int>>
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }

    }

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Response<int>>
    {
        private readonly IRepositorie<Brands> _rep;

        public UpdateBrandCommandHandler(IRepositorie<Brands> rep)
        {
            _rep = rep;
        }
        public async Task<Response<int>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandToUpdate = await _rep.GetByIdAsync(request.BrandId);

            if (brandToUpdate == null)
            {
                throw new KeyNotFoundException("La marca que desea modificar no existe");

            }
            else
            {
                brandToUpdate.BrandName = request.BrandName;

                await _rep.UpdateAsync(brandToUpdate);
            }

            return new Response<int>(request.BrandId);

          
              

        }
            
    }
    
}
