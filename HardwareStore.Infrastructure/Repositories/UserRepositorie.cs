using ApplicationServices.Interfaces.Repositories;
using HardwareHub.core.Entities;
using HardwareStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HardwareStore.Infrastructure.Repositories
{
    public class UserRepositorie : IUsersRepositorie
    {
        private readonly HardwareHubContext _context;

        public UserRepositorie(HardwareHubContext context)
        {
          _context = context;
        }

        



        public async Task<User> GetByCuil(int Cuil)
        {
            var user =  _context.User.FirstOrDefault(x => x.Cuil == Cuil);

            return user;
        }


        public async Task Delete(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.UserId == id);
            _context.User.Remove(user);
        }

       

        public async Task Insert(User user)
        {
            await _context.User.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.User.ToListAsync();

            return users;
        }
    }
}
