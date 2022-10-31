

using ApplicationServices.DTOs.DTOSadmins;
using HardwareHub.core.Entities;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IProductRepositorie:IGenericRepositorie<Product>
    {
       
        public Task<List<Product>> GetProductsByCategory(int category);
        public Task ChangeState(int id);

    }
}
