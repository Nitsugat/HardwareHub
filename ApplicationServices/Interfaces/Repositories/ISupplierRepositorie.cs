using HardwareStore.core.DTOs.DTOSadmins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface ISupplierRepositorie: IGenericRepositorie<SupplierDto>
    {
        public Task<SupplierDto> GetByCuil(string cuil);

    }
}
