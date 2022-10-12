using ApplicationServices.Interfaces.Repositories;
using ApplicationServices.Interfaces.Services;
using HardwareHub.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHub.Infrastructure.Services
{
    public class BrandServices:IBrandServices
    {
        private readonly IBrandsRepositorie _repo;
        public BrandServices(IBrandsRepositorie repo)
        {
            _repo = repo;
        }

        public async Task AddBrand(Brand brand)
        {
            await _repo.Insert(brand);
        }

        public Task<Brand> GetBrandById(int id)
        {
         
            return _repo.GetById(id);
        }

        public async Task RemoveBrand(int id)
        {
           await _repo.Delete(id);
        }
    }
}
