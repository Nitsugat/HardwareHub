using HardwareStore.core.DTOs.DTOSadmins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IPurchaseRepositorie: IGenericRepositorie<PurchaseDto>
    {


        public Task AddDetail(PurchaseDetailDto detail);
    }
}
