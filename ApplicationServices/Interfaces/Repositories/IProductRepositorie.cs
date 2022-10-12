using HardwareStore.core.DTOs.DTOSadmins;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IProductRepositorie
    {
        public Task<ProductFullDto> GetProductById(int Id);
        public Task<List<ProductDto>> GetProductsByCategory(int category);

        public Task<List<ProductDto>> GetAll();
        public Task ChangeState();
        public Task DeleteById(int id);
        public Task Save(ProductFullDto productFullDto);

    }
}
