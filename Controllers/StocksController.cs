using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class StocksController : Controller
    {
        private readonly IStockRepository _repo;
        public StocksController(IStockRepository repo)
            => _repo = repo;

        // GET: Stocks
        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var stock = await _repo.GetByProductIdAsync(id.Value);
            return stock == null ? NotFound() : View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create() => View();

        // POST: Stocks/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Stock stock)
        {
            if (!ModelState.IsValid) return View(stock);
            await _repo.AddAsync(stock);
            return RedirectToAction(nameof(Index));
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var stock = await _repo.GetByProductIdAsync(id.Value);
            return stock == null ? NotFound() : View(stock);
        }

        // POST: Stocks/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Stock stock)
        {
            if (id != stock.ProductId) return NotFound();
            if (!ModelState.IsValid) return View(stock);
            await _repo.UpdateAsync(stock);
            return RedirectToAction(nameof(Index));
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var stock = await _repo.GetByProductIdAsync(id.Value);
            return stock == null ? NotFound() : View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
