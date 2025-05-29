using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _db;
        public ReportRepository(ApplicationDbContext db) => _db = db;

        public async Task<IEnumerable<Report>> GetAllAsync()
            => await _db.Reports.ToListAsync();

        public async Task<Report?> GetByIdAsync(int id)
            => await _db.Reports.FirstOrDefaultAsync(r => r.Id == id);

        public async Task AddAsync(Report report)
        {
            _db.Reports.Add(report);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Report report)
        {
            _db.Reports.Update(report);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Reports.FindAsync(id);
            if (entity != null)
            {
                _db.Reports.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _db.Reports.AnyAsync(r => r.Id == id);
    }
}
