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
    public class PurchaseRepositorie : IPurchaseRepositorie
    {
        private readonly HardwareHubContext _context;
        public PurchaseRepositorie(HardwareHubContext context)
        {
            _context = context;
        }
        
        public async Task<List<PurchaseDto>> GetAll()
        {
            List<PurchaseDto> purchasesDto = new();

             var purchases = await _context.Purchase.Include(D=>D.Supplier).ToListAsync();
            if (purchases != null)
            {
                foreach (var purchase in purchases)
                {
                    purchasesDto.Add(new PurchaseDto
                    {
                        PurchaseId = purchase.PurchaseId,
                        Date = purchase.DatePurchase.ToString(),
                        SupplierName = purchase.Supplier.SupplierName,
                        TotalPrice = purchase.TotalPrice,
                        
                        
                    }) ;
                }

            }
            return purchasesDto;

        }



        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        private async Task InsertPurchase(PurchaseDto purchaseDto)
        {
            var supplier = _context.Supplier.FirstOrDefault(s=> s.SupplierName == purchaseDto.SupplierName);

            _context.Purchase.Add(new Purchase {

                DatePurchase = DateTime.Parse(purchaseDto.Date) ,
                TotalPrice = purchaseDto.TotalPrice,
                SupplierId = supplier.SupplierId,
                });

            await _context.SaveChangesAsync();
        }

        
       
        public async Task Save(PurchaseDto purchaseDto)
        {
            
        }

        public async Task AddDetail(PurchaseDetailDto detail)
        {
            modifystock(detail);
            SaveDetail(detail);
        }

        public void SaveDetail(PurchaseDetailDto detail)
        {

            _context.PurchaseDetail.Add(new PurchaseDetail
            {
                ProductId = detail.ProductId,
                PurchaseId = detail.PurchaseId,
                Quantitly = detail.Quantitly,
                UnitPrice = detail.UnitPrice,
            });

            

             _context.SaveChanges();
        }

        private void modifystock(PurchaseDetailDto detail)
        {
            var stock = _context.Stock.FirstOrDefault(s=>s.ProductId == detail.ProductId);

            if (stock != null)
            {
                stock.Quantitly += detail.Quantitly;
            }

            _context.SaveChanges();
        }
    }
}
