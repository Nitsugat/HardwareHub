using HardwareHub.core.Entities;


namespace ApplicationServices.Interfaces.Repositories
{
    public interface ISupplierRepositorie: IGenericRepositorie<Supplier>
    {
        public Task<Supplier> GetByCuil(string cuil);

    }
}
