using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTestMVC.Data;          // Ajusta al namespace de tu DbContext
using ProyectoTestMVC.Models;
using ProyectoTestMVC.ViewModels;    // Nuevo namespace para el ViewModel

namespace ProyectoTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;   // tu contexto EF

        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        // Hacemos el método async para cargar los datos
        public async Task<IActionResult> Index()
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
                    .Take(5)
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

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
