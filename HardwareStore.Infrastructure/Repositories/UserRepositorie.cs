using ApplicationServices.Interfaces.Repositories;
using HardwareHub.core.Entities;
using HardwareHub.Infrastructure.Data;

namespace HardwareHub.Infrastructure.Repositories
{
    public class UserRepositorie 
    {
        private readonly HardwareHubContext _context;

        public UserRepositorie(HardwareHubContext context)
        {
          _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByCuil(int cuil)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
