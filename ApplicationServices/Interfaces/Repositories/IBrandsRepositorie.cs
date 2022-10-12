

using HardwareHub.core.Entities;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IBrandsRepositorie:IGenericRepositorie<Brand>
    {
        Task<Brand> GetById(int id);
    }
}
