using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.ViewModels;

namespace ProyectoTestMVC.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _db;
        public DashboardRepository(ApplicationDbContext db)
            => _db = db;

        public async Task<DashboardViewModel> GetDashboardAsync(int recentTransactionCount = 5)
        {
            var vm = new DashboardViewModel
            {
                TotalProducts = await _db.Products.CountAsync(),
                TotalCategories = await _db.Categories.CountAsync(),
                TotalWarehouses = await _db.Warehouses.CountAsync(),
                TotalProviders = await _db.Providers.CountAsync(),
                LowStockAlerts = await _db.Alerts.CountAsync(a => !a.IsNotified),
                RecentTransactions = await _db.Transactions
                    .OrderByDescending(t => t.OccurredAt)
                    .Take(recentTransactionCount)
                    .Select(t => new DashboardViewModel.TransactionDto
                    {
                        OccurredAt = t.OccurredAt,
                        ProductName = t.Product.Name,
                        WarehouseName = t.Warehouse.Name,
                        Quantity = t.Quantity,
                        Type = t.Type.ToString()
                    })
                    .ToListAsync()
            };
            return vm;
        }
    }
}
