using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class AlertsController : Controller
    {
        private readonly IAlertRepository _repo;
        public AlertsController(IAlertRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var alert = await _repo.GetByIdAsync(id.Value);
            return alert == null ? NotFound() : View(alert);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Alert alert)
        {
            if (!ModelState.IsValid)
                return View(alert);

            await _repo.AddAsync(alert);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var alert = await _repo.GetByIdAsync(id.Value);
            return alert == null ? NotFound() : View(alert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Alert alert)
        {
            if (id != alert.Id) return NotFound();
            if (!ModelState.IsValid)
                return View(alert);

            await _repo.UpdateAsync(alert);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var alert = await _repo.GetByIdAsync(id.Value);
            return alert == null ? NotFound() : View(alert);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
