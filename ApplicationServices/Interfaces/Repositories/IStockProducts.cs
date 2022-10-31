using HardwareHub.core.Entities;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IStockProducts
    {
        public Task UpdateStock(Stock stock);
        public Task<List<Stock>> GetAllStock();

        public Task InsertStock(Stock entity);

    }
}
