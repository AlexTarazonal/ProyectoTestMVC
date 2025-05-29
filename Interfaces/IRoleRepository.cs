using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
