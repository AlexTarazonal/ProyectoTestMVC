using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider?> GetByIdAsync(int id);
        Task AddAsync(Provider provider);
        Task UpdateAsync(Provider provider);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
