using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db)
            => _db = db;

        public async Task<IEnumerable<Role>> GetAllAsync()
            => await _db.Roles.ToListAsync();

        public async Task<Role?> GetByIdAsync(int id)
            => await _db.Roles.FirstOrDefaultAsync(r => r.Id == id);

        public async Task AddAsync(Role role)
        {
            _db.Roles.Add(role);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _db.Roles.Update(role);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Roles.FindAsync(id);
            if (entity != null)
            {
                _db.Roles.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _db.Roles.AnyAsync(r => r.Id == id);
    }
}
