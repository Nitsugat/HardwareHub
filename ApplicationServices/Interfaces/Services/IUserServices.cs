using ApplicationServices.DTOs.DTOSadmins;


namespace ApplicationServices.Interfaces.Services
{
    public interface IUserServices:IBaseServices<UserDto>
    {
        Task<UserDto> GetUserByCuil(int cuil);
     
    }
}
