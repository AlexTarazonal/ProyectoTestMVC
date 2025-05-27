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
            // Aplica snake_case a tablas y columnas
           

            // Mapea la clave compuesta de Stock
            modelBuilder.Entity<Stock>()
                        .HasKey(s => new { s.ProductId, s.WarehouseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
