using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report?> GetByIdAsync(int id);
        Task AddAsync(Report report);
        Task UpdateAsync(Report report);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
