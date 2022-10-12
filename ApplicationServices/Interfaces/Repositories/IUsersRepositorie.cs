using HardwareStore.core.DTOs.DTOSadmins;

namespace ApplicationServices.Interfaces.Repositories;

public interface IUsersRepositorie: IGenericRepositorie<UserDto>
{

    public Task<UserDto> GetByCuil(int cuil);
    
}
