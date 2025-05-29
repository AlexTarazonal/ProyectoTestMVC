using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoTestMVC.Models;
using ProyectoTestMVC.ViewModels;

namespace ProyectoTestMVC.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductListViewModel>> GetAllAsync(string? search = null, int? categoryId = null);
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
