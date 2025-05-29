using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly ApplicationDbContext _context;
        public AlertRepository(ApplicationDbContext context)
            => _context = context;

        public async Task<IEnumerable<Alert>> GetAllAsync()
            => await _context.Alerts.ToListAsync();

        public async Task<Alert?> GetByIdAsync(int id)
            => await _context.Alerts.FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAsync(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Alert alert)
        {
            _context.Alerts.Update(alert);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Alerts.FindAsync(id);
            if (entity != null)
            {
                _context.Alerts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Alerts.AnyAsync(a => a.Id == id);
    }
}
