using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using MediatR;
using HardwareHub.core.Entities;

namespace ApplicationServices.Services.CreateCommand.BrandCommands
{
    public class CreateBrandCommand: IRequest<Response<int>>
    {
        public string BrandName { get; set; }
    }
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Response<int>>
    {
        private readonly IRepositorie<Brands> _rep;

        public CreateBrandCommandHandler(IRepositorie<Brands> rep)
        {
            _rep = rep;
        }

        public async Task<Response<int>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {

            Brands brand = new();

                brand.BrandName = request.BrandName;

             var data = await _rep.AddAsync(brand);

            
            return new Response<int>(data.BrandId);
        }
    }
}
