using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Wrappers;
using HardwareHub.core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.CreateCommand.SupplierCreateCommand
{
    public class SupplierCreateCommand:IRequest<Response<int>>
    {
        public string? SupplierName { get; set; }
        public string? SupplierSurname { get; set; }
        public string? CUIL { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
    }

    public class SupplierCreateCommandHandler : IRequestHandler<SupplierCreateCommand, Response<int>>
    {
        private readonly IRepositorie<Supplier> _rep;

        public SupplierCreateCommandHandler(IRepositorie<Supplier> rep)
        {
            _rep = rep;
        }

        public  async Task<Response<int>> Handle(SupplierCreateCommand request, CancellationToken cancellationToken)
        {
            Supplier supplier = new()
            {
                CUIL = request.CUIL,
                EmailAddress = request.EmailAddress,
                SupplierName = request.SupplierName,
                PhoneNumber = request.PhoneNumber,
                SupplierSurname = request.SupplierSurname,
                

            };

            var data = await _rep.AddAsync(supplier);

            return new Response<int>(data.SupplierId);
        }
    }
}
