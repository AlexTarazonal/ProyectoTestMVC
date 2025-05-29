using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.ViewModels;
using ProyectoTestMVC.Models;
namespace ProyectoTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboardRepository _dashboard;

        public HomeController(ILogger<HomeController> logger,
                              IDashboardRepository dashboard)
        {
            _logger = logger;
            _dashboard = dashboard;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _dashboard.GetDashboardAsync();
            return View(vm);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
