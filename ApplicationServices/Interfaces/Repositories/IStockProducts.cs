using HardwareStore.core.DTOs.DTOSadmins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IStockProducts
    {
        public Task UpdateStock(StockDto stock);
        public Task<List<StockDto>> GetAllStock();

        public Task InsertStock(ProductDto entity);

    }
}
