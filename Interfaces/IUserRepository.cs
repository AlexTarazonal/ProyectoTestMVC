using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
