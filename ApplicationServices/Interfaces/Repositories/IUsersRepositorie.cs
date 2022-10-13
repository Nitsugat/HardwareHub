
using HardwareHub.core.Entities;

namespace ApplicationServices.Interfaces.Repositories;

public interface IUsersRepositorie: IGenericRepositorie<User>
{

    public Task<User> GetByCuil(int cuil);
    
}
