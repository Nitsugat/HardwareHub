using ApplicationServices.DTOs.DTOSadmins;
using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;

namespace ApplicationServices.Services.Querys.HardwareCategorieQueries
{
    public class HardwareCategorieGetAllCommand:IRequest<Response<List<HardwareCategoryDto>>>
    {
    }

    public class HardwareCategorieGetAllCommandHandler : IRequestHandler<HardwareCategorieGetAllCommand, Response<List<HardwareCategoryDto>>>
    {
        private readonly IRepositorie<HardwareCategory> _rep;

        public HardwareCategorieGetAllCommandHandler(IRepositorie<HardwareCategory> rep)
        {
            _rep = rep;
        }

        public async Task<Response<List<HardwareCategoryDto>>> Handle(HardwareCategorieGetAllCommand request, CancellationToken cancellationToken)
        {
           var categories = await _rep.ListAsync(cancellationToken);

            if (categories == null)
            {
                return new Response<List<HardwareCategoryDto>>("No se encontraron categorias, por favor ingrese nuevas categorias para poder verlas");
            }

            List<HardwareCategoryDto> categoriesDto = new();

            foreach (var category in categories)
            {
                HardwareCategoryDto categoryDto = new();

                categoryDto.CategoryId = category.CategoryId;
                categoryDto.Category = category.Category;
                categoryDto.Gaing = category.Gaing;

                categoriesDto.Add(categoryDto);
            }

            return new Response<List<HardwareCategoryDto>>(categoriesDto);
        }
    }
}
