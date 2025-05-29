using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock?> GetByProductIdAsync(int productId);
        Task AddAsync(Stock stock);
        Task UpdateAsync(Stock stock);
        Task DeleteAsync(int productId);
        Task<bool> ExistsAsync(int productId);
    }
}
