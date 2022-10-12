using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Services
{
    public interface IBaseServices<T> where T : class
    {
        Task<List<T>> GetAll();
        Task AddNew(T entity);
        Task<T> GetById(int id);
        Task Update(int id);
        Task Delete(int id);

    }
}
