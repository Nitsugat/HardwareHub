
using Ardalis.Specification;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IRepositorie<T>: IRepositoryBase<T> where T : class
    {

    }
    public interface IReadInterface<T>: IReadRepositoryBase<T> where T : class
    {

    }
    
}
