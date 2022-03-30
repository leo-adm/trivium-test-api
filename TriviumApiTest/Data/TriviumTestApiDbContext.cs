using Microsoft.EntityFrameworkCore;
using TriviumApiTest.Models;

namespace TriviumApiTest.Data
{
    public class TriviumTestApiDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        public TriviumTestApiDbContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Cliente");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Produto");
            });

            modelBuilder.Entity<Purchase>(entity => 
            {
                entity.ToTable("Compra");

                entity.HasOne(x => x.Client)
                    .WithMany(x => x.Purchases)
                    .HasForeignKey(x => x.ClientId);
            });

            modelBuilder.Entity<PurchaseItem>(entity =>
            {
                entity.ToTable("CompraItem");

                entity.HasOne(x => x.Product)
                    .WithMany(x => x.PurchaseItems)
                    .HasForeignKey(x => x.ProductId);

                entity.HasOne(x => x.Purchase)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.PurchaseId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
