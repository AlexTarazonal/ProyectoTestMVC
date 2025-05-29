using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;
using ProyectoTestMVC.ViewModels;

namespace ProyectoTestMVC.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
            => _db = db;

        public async Task<IEnumerable<ProductListViewModel>> GetAllAsync(string? search = null, int? categoryId = null)
        {
            var query = _db.Products
                .Include(p => p.Category)
                .Include(p => p.Stocks)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.Contains(search) || p.Barcode!.Contains(search));
            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            return await query
                .Select(p => new ProductListViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Barcode = p.Barcode ?? string.Empty,
                    Price = p.Price,
                    CategoryName = p.Category!.Name,
                    MinimumStock = p.MinimumStock,
                    TotalStock = p.Stocks.Sum(s => s.Quantity)
                })
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
            => await _db.Products
                .Include(p => p.Category)
                .Include(p => p.Stocks).ThenInclude(s => s.Warehouse)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Products.FindAsync(id);
            if (entity != null)
            {
                _db.Products.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _db.Products.AnyAsync(p => p.Id == id);

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
            => await _db.Categories.ToListAsync();
    }
}
