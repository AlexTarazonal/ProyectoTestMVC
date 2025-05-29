using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
            => _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(int id)
            => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Categories.AnyAsync(c => c.Id == id);
    }
}
