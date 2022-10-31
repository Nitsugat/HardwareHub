

using HardwareHub.core.Entities;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IPurchaseRepositorie: IGenericRepositorie<Purchase>
    {


        public Task AddDetail(PurchaseDetail detail);
    }
}
