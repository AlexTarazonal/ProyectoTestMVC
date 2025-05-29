using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<Warehouse?> GetByIdAsync(int id);
        Task AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
