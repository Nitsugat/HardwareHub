using ApplicationServices.Interfaces.Repositories;
using HardwareHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHub.Infrastructure.Repositories
{


    public class GenericRepositorie<T> : IGenericRepositorie<T> where T : class
    {

        protected readonly HardwareHubContext _context;

        public GenericRepositorie(HardwareHubContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
         
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            var list =  _context.Set<T>().ToList();
            return list ;
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Insert(T entity)
        {

            try
            {
                if (entity != null)
                {
                    await _context.AddAsync(entity);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            try
            {
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

       

      
    }
}
