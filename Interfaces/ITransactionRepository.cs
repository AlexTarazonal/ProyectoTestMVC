using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
