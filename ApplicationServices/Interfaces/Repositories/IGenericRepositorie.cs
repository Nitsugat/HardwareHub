using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Repositories
{
    public interface IGenericRepositorie<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task Update(T entity);
        public Task Delete(int id);
        public Task<T> Insert(T entity);

        public Task<T> GetById(int id);
     
    }
}
