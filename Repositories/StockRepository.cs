using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _db;
        public StockRepository(ApplicationDbContext db) => _db = db;

        public async Task<IEnumerable<Stock>> GetAllAsync()
            => await _db.Stocks.ToListAsync();

        public async Task<Stock?> GetByProductIdAsync(int productId)
            => await _db.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == productId);

        public async Task AddAsync(Stock stock)
        {
            _db.Stocks.Add(stock);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stock stock)
        {
            _db.Stocks.Update(stock);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var entity = await _db.Stocks.FindAsync(productId);
            if (entity != null)
            {
                _db.Stocks.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int productId)
            => await _db.Stocks.AnyAsync(s => s.ProductId == productId);
    }
}
