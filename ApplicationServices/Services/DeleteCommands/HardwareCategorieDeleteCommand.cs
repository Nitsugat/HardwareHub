using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;

namespace ApplicationServices.Services.DeleteCommands
{
    public class HardwareCategorieDeleteCommand:IRequest<Response<int>>
    {
        public int CategorieId { get; set; }
    }

    public class HardwareCategorieDeleteCommandHandler: IRequestHandler<HardwareCategorieDeleteCommand,Response<int>>
    {
        private readonly IRepositorie<HardwareCategory> _rep;

        public HardwareCategorieDeleteCommandHandler(IRepositorie<HardwareCategory> rep)
        {
            _rep = rep;
        }

        public async Task<Response<int>> Handle(HardwareCategorieDeleteCommand request, CancellationToken cancellationToken)
        {

          var categorie =   await _rep.GetByIdAsync(request.CategorieId);

            if (categorie == null)
            {
                throw new KeyNotFoundException($"La categoria con el id {request.CategorieId} no existe, por lo tanto no se puede eliminar.");

            }
           

           await  _rep.DeleteAsync(categorie);

            return new Response<int>(request.CategorieId);
        }
    }

    



}
