
using HardwareHub.core.Entities;

namespace ApplicationServices.Interfaces.Services
{
    public interface IBrandServices
    {
        public Task AddBrand(Brand brand);
        public Task RemoveBrand(int id);
        public Task<Brand> GetBrandById(int id);

    }
}
