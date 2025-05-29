using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repo;
        public UsersController(IUserRepository repo)
            => _repo = repo;

        // GET: Users
        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var user = await _repo.GetByIdAsync(id.Value);
            return user == null ? NotFound() : View(user);
        }

        // GET: Users/Create
        public IActionResult Create() => View();

        // POST: Users/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid) return View(user);
            await _repo.AddAsync(user);
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var user = await _repo.GetByIdAsync(id.Value);
            return user == null ? NotFound() : View(user);
        }

        // POST: Users/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id) return NotFound();
            if (!ModelState.IsValid) return View(user);
            await _repo.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var user = await _repo.GetByIdAsync(id.Value);
            return user == null ? NotFound() : View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
