using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleRepository _repo;
        public RolesController(IRoleRepository repo)
            => _repo = repo;

        // GET: Roles
        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var role = await _repo.GetByIdAsync(id.Value);
            return role == null ? NotFound() : View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
            => View();

        // POST: Roles/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            if (!ModelState.IsValid) return View(role);
            await _repo.AddAsync(role);
            return RedirectToAction(nameof(Index));
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var role = await _repo.GetByIdAsync(id.Value);
            return role == null ? NotFound() : View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Role role)
        {
            if (id != role.Id) return NotFound();
            if (!ModelState.IsValid) return View(role);
            await _repo.UpdateAsync(role);
            return RedirectToAction(nameof(Index));
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var role = await _repo.GetByIdAsync(id.Value);
            return role == null ? NotFound() : View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
