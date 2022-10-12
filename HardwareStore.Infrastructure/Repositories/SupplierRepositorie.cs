using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.core.Entities;
using HardwareStore.Infrastructure.Data;
using HardwareStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Repositories
{
    public class SupplierRepositorie : ISupplierRepositorie
    {

        private readonly HardwareHubContext _context;

        public SupplierRepositorie(HardwareHubContext context)
        {
           _context = context;
        }

        public async Task<List<SupplierDto>> GetAll()
        {
            List<SupplierDto> supplierListDto = new();
            var supplierListContext = await _context.Supplier.ToListAsync();

            if (supplierListContext !=null)
            {

                foreach (var supplier in supplierListContext)
                {
                    supplierListDto.Add(new SupplierDto
                    {
                        SupplierId= supplier.SupplierId,
                        SupplierName = supplier.SupplierName,
                        SupplierSurname=supplier.SupplierSurname,
                        CUIL = supplier.CUIL,
                        EmailAddress = supplier.EmailAddress,
                        PhoneNumber = supplier.PhoneNumber,
                       


                    });

                }

                return supplierListDto;
            }
            else
            {
                return supplierListDto;
            }

            
        }

        public Task<SupplierDto> GetByCuil(string cuil)
        {
            throw new NotImplementedException();
        }

      

        public async Task Save(SupplierDto supplierDto)
        {
            if (supplierDto.SupplierId > 0)
            {
               await Update(supplierDto);
            }
            else if (supplierDto.SupplierId == 0 || supplierDto.SupplierId == null)
            {
                await Insert(supplierDto);
            }
        }

        private async Task Update(SupplierDto supplierDto)
        {
            var supplier = _context.Supplier.FirstOrDefault(s => s.SupplierId == supplierDto.SupplierId);

            if (supplier != null & supplier.SupplierId > 0 )
            {
                if (supplierDto.SupplierName != null & supplierDto.SupplierName != "string")
                    supplier.SupplierName = supplierDto.SupplierName;

                if (supplierDto.SupplierSurname != null & supplierDto.SupplierSurname != "string")
                    supplier.SupplierSurname = supplierDto.SupplierSurname;

                if (supplierDto.PhoneNumber != null & supplierDto.PhoneNumber != "string")
                supplier.PhoneNumber = supplierDto.PhoneNumber;

                if (supplierDto.EmailAddress != null & supplierDto.EmailAddress != "string")
                    supplier.EmailAddress = supplierDto.EmailAddress;
            }

           await _context.SaveChangesAsync();
        }


        private async Task Insert(SupplierDto supplierDto)
        {
            if (supplierDto != null)
            {
                _context.Supplier.Add(new Supplier
                {
                    SupplierId = supplierDto.SupplierId,
                    SupplierName = supplierDto.SupplierName,
                    SupplierSurname = supplierDto.SupplierSurname,
                    CUIL = supplierDto.CUIL,
                    EmailAddress = supplierDto.EmailAddress,
                    PhoneNumber = supplierDto.PhoneNumber,

                });
            }

            await _context.SaveChangesAsync();
            
        }


        public async Task Delete(int id)
        {
           var supplier = _context.Supplier.FirstOrDefault(s=>s.SupplierId == id);

            if (supplier != null)
            {
                _context.Remove(supplier);
            }

           await _context.SaveChangesAsync();
        }



    }
}
