using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _db;
        public ProviderRepository(ApplicationDbContext db)
            => _db = db;

        public async Task<IEnumerable<Provider>> GetAllAsync()
            => await _db.Providers.ToListAsync();

        public async Task<Provider?> GetByIdAsync(int id)
            => await _db.Providers.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Provider provider)
        {
            _db.Providers.Add(provider);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Provider provider)
        {
            _db.Providers.Update(provider);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Providers.FindAsync(id);
            if (entity != null)
            {
                _db.Providers.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _db.Providers.AnyAsync(p => p.Id == id);
    }
}
