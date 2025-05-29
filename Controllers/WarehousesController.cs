using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly IWarehouseRepository _repo;
        public WarehousesController(IWarehouseRepository repo)
            => _repo = repo;

        // GET: Warehouses
        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        // GET: Warehouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var warehouse = await _repo.GetByIdAsync(id.Value);
            return warehouse == null ? NotFound() : View(warehouse);
        }

        // GET: Warehouses/Create
        public IActionResult Create() => View();

        // POST: Warehouses/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Warehouse warehouse)
        {
            if (!ModelState.IsValid) return View(warehouse);
            await _repo.AddAsync(warehouse);
            return RedirectToAction(nameof(Index));
        }

        // GET: Warehouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var warehouse = await _repo.GetByIdAsync(id.Value);
            return warehouse == null ? NotFound() : View(warehouse);
        }

        // POST: Warehouses/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Warehouse warehouse)
        {
            if (id != warehouse.Id) return NotFound();
            if (!ModelState.IsValid) return View(warehouse);
            await _repo.UpdateAsync(warehouse);
            return RedirectToAction(nameof(Index));
        }

        // GET: Warehouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var warehouse = await _repo.GetByIdAsync(id.Value);
            return warehouse == null ? NotFound() : View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
