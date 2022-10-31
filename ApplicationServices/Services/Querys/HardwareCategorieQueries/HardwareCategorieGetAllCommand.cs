using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;

namespace ApplicationServices.Services.Querys.HardwareCategorieQueries
{
    public class HardwareCategorieGetAllCommand:IRequest<Response<List<HardwareCategory>>>
    {
    }

    public class HardwareCategorieGetAllCommandHandler : IRequestHandler<HardwareCategorieGetAllCommand, Response<List<HardwareCategory>>>
    {
        private readonly IRepositorie<HardwareCategory> _rep;

        public HardwareCategorieGetAllCommandHandler(IRepositorie<HardwareCategory> rep)
        {
            _rep = rep;
        }

        public async Task<Response<List<HardwareCategory>>> Handle(HardwareCategorieGetAllCommand request, CancellationToken cancellationToken)
        {
           var categories = await _rep.ListAsync(cancellationToken);

            return new Response<List<HardwareCategory>>(categories);
        }
    }
}
