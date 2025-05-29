using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
            => _db = db;

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _db.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id)
            => await _db.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Users.FindAsync(id);
            if (entity != null)
            {
                _db.Users.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _db.Users.AnyAsync(u => u.Id == id);
    }
}
