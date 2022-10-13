using ApplicationServices.DTOs.DTOSadmins;
using ApplicationServices.Interfaces.Services;

namespace HardwareHub.Infrastructure.Services
{
    public class UserServices : IUserServices
    {
        public Task AddNew(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByCuil(int cuil)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
