using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // para SnakeCaseNamingConvention
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Stock (ya lo tenías)
            modelBuilder.Entity<Stock>()
                .HasKey(s => new { s.ProductId, s.WarehouseId });

            // Transaction → Product (1:N)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Product)
                .WithMany(p => p.Transactions)   // deja p.Transactions en tu modelo Product
                .HasForeignKey(t => t.ProductId);

            // Transaction → Warehouse (1:N)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Warehouse)
                .WithMany(w => w.Transactions)   // deja w.Transactions en tu modelo Warehouse
                .HasForeignKey(t => t.WarehouseId);

            // Transaction → Provider (opcional)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Provider)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.ProviderId);

            // Transaction → CreatedByUser (opcional)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.TransactionsCreated)
                .HasForeignKey(t => t.CreatedBy);

            base.OnModelCreating(modelBuilder);
        }
    }
}
