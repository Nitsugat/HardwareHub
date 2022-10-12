
using ApplicationServices.Interfaces.Repositories;
using HardwareHub.core.Entities;
using HardwareStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.Infrastructure.Repositories
{
    public class BrandRepositorie: IBrandsRepositorie
    {
        private readonly HardwareHubContext _context;

        public BrandRepositorie(HardwareHubContext context)
        {
            this._context = context;
        }



        public async Task<List<Brand>> GetAll()
        {

            var brands = await _context.Brand.ToListAsync();

            return brands;

        }

        public async Task Delete(int id)
        {


             _context.Brand.Remove(_context.Brand.FirstOrDefault(b => b.BrandId == id));

            await _context.SaveChangesAsync();
           
        }

        public async Task<Brand> GetById(int id)
        {
            var brand =  _context.Brand.FirstOrDefault(b => b.BrandId.Equals(id));

            if (brand != null)
            {
                return brand;
            }
            return brand;
       
        }

        public async Task Insert(Brand brand)
        {

            _context.Brand.Add(brand);

             await _context.SaveChangesAsync();
           
        }

 
        public async Task Update(Brand brand)
        {

       
            
        }


        private async Task<bool> Exist(int Id)
        {
            var brands = await _context.Brand.ToListAsync();
            bool exist = false;
            foreach (var brand in brands)
            {
                if (Id != brand.BrandId)
                {

                }
                else
                {
                    exist = true;
                }
            }

            return exist;
        }

  
    }
}
