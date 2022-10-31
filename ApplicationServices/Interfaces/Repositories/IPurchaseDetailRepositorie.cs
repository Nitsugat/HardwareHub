using HardwareHub.core.Entities;


namespace ApplicationServices.Interfaces.Repositories
{
    public interface IPurchaseDetailRepositorie
    {
        public Task<List<PurchaseDetail>> InsertDetail();
        public Task<List<PurchaseDetail>> GetDetail(int Id);
    }
}
