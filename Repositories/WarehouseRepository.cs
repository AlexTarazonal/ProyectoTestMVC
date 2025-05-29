using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _db;
        public WarehouseRepository(ApplicationDbContext db)
            => _db = db;

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
            => await _db.Warehouses.ToListAsync();

        public async Task<Warehouse?> GetByIdAsync(int id)
            => await _db.Warehouses.FirstOrDefaultAsync(w => w.Id == id);

        public async Task AddAsync(Warehouse warehouse)
        {
            _db.Warehouses.Add(warehouse);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            _db.Warehouses.Update(warehouse);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Warehouses.FindAsync(id);
            if (entity != null)
            {
                _db.Warehouses.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _db.Warehouses.AnyAsync(w => w.Id == id);
    }
}
