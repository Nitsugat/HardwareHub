using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.core.Entities;
using HardwareStore.Infrastructure.Data;
using HardwareStore.Infrastructure.Entities;
using HardwareStore.Infrastructure.Services;
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

        

        public async Task<List<UserDto>> GetAll()
        {
            List<UserDto> userDto = new(); 
            var userContext = await _context.User.Include(b => b.Type).AsNoTracking().ToListAsync(); 

            if ( userContext != null)
            {
                foreach (var user in userContext)
                {
                    userDto.Add(new UserDto
                    {
                        UserId = user.UserId,
                        UserName=user.Name,
                        EmailAddress= user.EmailAddress,
                        Cuil = user.Cuil,
                        TypeUser = user.Type.Type,

                    }) ;
                }

                return userDto;
            }

            return userDto;
        }
        public Task<UserDto> GetByCuil(int Cuil)
        {
            throw new NotImplementedException();
        }


        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

       

        private async Task Insert(UserDto entity)
        {
            var usertype = _context.TypeUser.FirstOrDefault(s=>s.Type == entity.TypeUser);

            if (entity != null)
            {

           
            _context.User.Add(new User
            {
                Name = entity.UserName,
                Surname = entity.Surname,
                Cuil = entity.Cuil,
                EmailAddress = entity.EmailAddress,
                Password = entity.Password,
                TypeUserId = usertype.TypeId,

            });

               await _context.SaveChangesAsync();
            }
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }


        public Task Save(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
