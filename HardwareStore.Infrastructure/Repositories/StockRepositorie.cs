using ApplicationServices.Interfaces.Repositories;
using HardwareHub.core.Entities;
using HardwareHub.Infrastructure.Data;

namespace HardwareHub.Infrastructure.Repositories
{
    public class StockRepositorie  
    {
        private readonly HardwareHubContext _context;

        public StockRepositorie(HardwareHubContext context)
        {
            _context = context;
        }

        public Task<List<Stock>> GetAllStock()
        {
            throw new NotImplementedException();
        }

        public Task InsertStock(Stock entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStock(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
