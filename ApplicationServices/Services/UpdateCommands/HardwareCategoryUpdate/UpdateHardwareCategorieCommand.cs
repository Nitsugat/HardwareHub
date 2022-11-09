using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.UpdateCommands.HardwareCategoryUpdate
{
    public class UpdateHardwareCategorieCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public double Gaing { get; set; }
    }
    public class UpdateHardwareCategorieCommandHandler : IRequestHandler<UpdateHardwareCategorieCommand, Response<int>>
    {
        private readonly IRepositorie<HardwareCategory>_rep;

        public UpdateHardwareCategorieCommandHandler(IRepositorie<HardwareCategory> rep)
        {
            _rep = rep;
        }

        public async Task<Response<int>> Handle(UpdateHardwareCategorieCommand request, CancellationToken cancellationToken)
        {


           var category = await _rep.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new FileNotFoundException("Hubo un error al modificar la categoria solicitada, intentelo nuevamente");
            }

            category.Category = request.Category;
            category.Gaing = request.Gaing;
           await _rep.UpdateAsync(category);

            return new Response<int>(request.Id,message:$"Se modifico correctamente la categoria con id {request.Id}");


        }
    }
}
