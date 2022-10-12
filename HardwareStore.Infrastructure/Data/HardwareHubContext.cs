using Microsoft.EntityFrameworkCore;
using HardwareHub.core.Entities;

namespace HardwareStore.Infrastructure.Data
{
    public class HardwareHubContext: DbContext
    {
        public HardwareHubContext(DbContextOptions<HardwareHubContext> options)
            :base(options)
        {
                
        }


        public DbSet<Brand> Brand => Set<Brand>();
        public DbSet<HardwareCategory> HardwareCategory => Set<HardwareCategory>();
        public DbSet<Product> Product => Set<Product>();
        public DbSet<Stock> Stock => Set<Stock>();
        public DbSet<Supplier> Supplier => Set<Supplier>();
        public DbSet<Sale> Sale => Set<Sale>();
        public DbSet<DetailSale> DetailSale => Set<DetailSale>();
        public DbSet<TypeUser> TypeUser => Set<TypeUser>();
        public DbSet<User> User => Set<User>();
        public DbSet<Client> Client => Set<Client>();
        public DbSet<Purchase> Purchase => Set<Purchase>();
        public DbSet<PurchaseDetail> PurchaseDetail => Set<PurchaseDetail>();



    }
}
//tarea: hilo ejecutado en el proce, en paralelo con otros
