using ApplicationServices.DTOs.DTOSadmins;
using ApplicationServices.Interfaces.Repositories;
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
    public class GetAllBrandsQuery:IRequest<List<BrandDto>>
    {



        public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandDto>>
        {
            private readonly IRepositorie<Brands> _rep;

            public GetAllBrandsQueryHandler(IRepositorie<Brands> rep)
            {
                _rep = rep;
            }
          

            public async Task<List<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var list = await _rep.ListAsync();
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

                    return listBrandDto;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                


               
            }
        }

       
        
    }
}
    

