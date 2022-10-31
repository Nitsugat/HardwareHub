using ApplicationServices.Interfaces.Repositories;
using HardwareHub.core.Entities;
using HardwareHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HardwareHub.Infrastructure.Repositories
{
    public class SupplierRepositorie 
    {

        private readonly HardwareHubContext _context;

        public SupplierRepositorie(HardwareHubContext context)
        {
           _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supplier>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetByCuil(string cuil)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
