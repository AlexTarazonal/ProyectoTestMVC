using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface IAlertRepository
    {
        Task<IEnumerable<Alert>> GetAllAsync();
        Task<Alert?> GetByIdAsync(int id);
        Task AddAsync(Alert alert);
        Task UpdateAsync(Alert alert);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
