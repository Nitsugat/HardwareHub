using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.CreateCommand.HardwareCategories
{
    public class HardwareCategorieCreateCommand:IRequest<Response<int>>
    {
        public string? Category { get; set; }
        public double Gaing { get; set; }

    }

    public class HardwareCategorieCreateCommandHandler : IRequestHandler<HardwareCategorieCreateCommand,Response<int>>
    {
        private readonly IRepositorie<HardwareCategory> _rep;

        public HardwareCategorieCreateCommandHandler(IRepositorie<HardwareCategory> rep)
        {
            _rep = rep;
        }

        public async Task<Response<int>> Handle(HardwareCategorieCreateCommand request, CancellationToken cancellationToken)
        {
            HardwareCategory category = new()
            {
                Category = request.Category,
                Gaing = request.Gaing,
            };

            var data = await _rep.AddAsync(category,cancellationToken);

         

            return new Response<int>(data.CategoryId);
        }
    }
}
