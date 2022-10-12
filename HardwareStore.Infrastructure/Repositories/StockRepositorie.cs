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
    public class StockRepositorie: IStockProducts  
    {
        private readonly HardwareHubContext _context;

        public StockRepositorie(HardwareHubContext context)
        {
            _context = context;
        }

        public async Task<List<StockDto>> GetAllStock()
        {
            List<StockDto> stocksDto = new();

            var stocks = await _context.Stock.ToListAsync();

            if (stocks != null)
            {
                foreach (var stock in stocks)
                {
                    stocksDto.Add(new StockDto
                    {
                        StockId= stock.StockId,
                        ProductName = stock.Product.ProductName,
                        PublicPrice = stock.PublicPrice,
                        Quantitly= stock.Quantitly,
                        DateUpdate= stock.DateUpdate.ToString(),
                       

                    }) ;
                }
            }

            return stocksDto;
        }

        public async Task InsertStock(ProductDto productDto)
        {
            _context.Stock.Add(new Stock
            {
                StockId= productDto.ProductId,
                ProductId = productDto.ProductId,
                PublicPrice = 0,
                Quantitly = 0,
                DateUpdate = DateTime.Now,
            });

             await _context.SaveChangesAsync();
        }

        public Task UpdateStock(StockDto stock)
        {
            throw new NotImplementedException();
        }
    }
}
