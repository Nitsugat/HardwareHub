using ApplicationServices.DTOs.DTOSadmins;
using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Specifications;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.Querys.QuerysBrand
{
    public class GetAllBrandsQuery:IRequest<PagedResponse<List<BrandDto>>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string? BrandName { get; set; }

    }



    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, PagedResponse<List<BrandDto>>>
        {
            private readonly IRepositorie<Brands> _rep;

            public GetAllBrandsQueryHandler(IRepositorie<Brands> rep)
            {
                _rep = rep;
            }
          

            public async Task<PagedResponse<List<BrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
            {
            
                var list = await _rep.ListAsync(new PagedBrandSpecifications(request.PageSize, request.PageIndex, request.BrandName));
                List<BrandDto> listBrandDto = new();

                foreach (var item in list)
                {
                    BrandDto brand = new()
                    {
                        Id = item.BrandId,
                        BrandName = item.BrandName,
                    };

                    listBrandDto.Add(brand);

                };



                if (listBrandDto == null)
                    throw new Exception("Brands not found");

                return new PagedResponse<List<BrandDto>>(listBrandDto, request.PageSize, request.PageIndex);



            }
               
    }
}

       
      

    

