using ApplicationServices.Interfaces.Repositories;
using HardwareHub.core.Entities;
using HardwareHub.Infrastructure.Data;

namespace HardwareHub.Infrastructure.Repositories
{
    public class ProductRepositorie 
    {
     
        public Task ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByCategory(int category)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
