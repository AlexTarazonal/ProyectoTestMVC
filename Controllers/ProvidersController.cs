using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly IProviderRepository _repo;

        public ProvidersController(IProviderRepository repo)
            => _repo = repo;

        // GET: Providers
        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        // GET: Providers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var provider = await _repo.GetByIdAsync(id.Value);
            return provider == null ? NotFound() : View(provider);
        }

        // GET: Providers/Create
        public IActionResult Create() => View();

        // POST: Providers/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Provider provider)
        {
            if (!ModelState.IsValid) return View(provider);
            await _repo.AddAsync(provider);
            return RedirectToAction(nameof(Index));
        }

        // GET: Providers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var provider = await _repo.GetByIdAsync(id.Value);
            return provider == null ? NotFound() : View(provider);
        }

        // POST: Providers/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Provider provider)
        {
            if (id != provider.Id) return NotFound();
            if (!ModelState.IsValid) return View(provider);
            await _repo.UpdateAsync(provider);
            return RedirectToAction(nameof(Index));
        }

        // GET: Providers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var provider = await _repo.GetByIdAsync(id.Value);
            return provider == null ? NotFound() : View(provider);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
