using ApplicationServices.Interfaces.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using HardwareHub.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHub.Infrastructure.Repositories
{
    public class RepositorieArdalis<T>: RepositoryBase<T>,IRepositorie<T> where T: class
    {
        private readonly HardwareHubContext _context;
        public RepositorieArdalis(HardwareHubContext context):base(context)
        {
            _context = context;
        }
    }
}
