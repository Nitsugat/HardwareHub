using HardwareStore.core.DTOs.DTOSadmins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IPurchaseDetailRepositorie
    {
        public Task<List<PurchaseDetailDto>> InsertDetail();
        public Task<List<PurchaseDetailDto>> GetDetail(int Id);
    }
}
