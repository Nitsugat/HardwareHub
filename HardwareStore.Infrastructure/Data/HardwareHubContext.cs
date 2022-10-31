using Microsoft.EntityFrameworkCore;
using HardwareHub.core.Entities;
using HardwareHub.core.Entities.BasesEntities;

namespace HardwareHub.Infrastructure.Data
{
    public class HardwareHubContext: DbContext
    {
        public HardwareHubContext(DbContextOptions<HardwareHubContext> options)
            :base(options)
        {
                
        }


        public DbSet<Brands> Brands { get; set; }
        //public DbSet<Brands> Brands => Set<Brands>();
        public DbSet<HardwareCategory> HardwareCategories => Set<HardwareCategory>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<DetailSale> DetailSales => Set<DetailSale>();
        public DbSet<TypeUser> TypeUsers => Set<TypeUser>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<PurchaseDetail> PurchaseDetails => Set<PurchaseDetail>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = 0;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreateBy = 1;
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        entry.Entity.State = false;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

