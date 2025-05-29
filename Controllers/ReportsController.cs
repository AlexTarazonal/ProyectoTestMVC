using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportRepository _repo;
        public ReportsController(IReportRepository repo) => _repo = repo;

        // GET: Reports
        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var report = await _repo.GetByIdAsync(id.Value);
            return report == null ? NotFound() : View(report);
        }

        // GET: Reports/Create
        public IActionResult Create() => View();

        // POST: Reports/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Report report)
        {
            if (!ModelState.IsValid) return View(report);
            await _repo.AddAsync(report);
            return RedirectToAction(nameof(Index));
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var report = await _repo.GetByIdAsync(id.Value);
            return report == null ? NotFound() : View(report);
        }

        // POST: Reports/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Report report)
        {
            if (id != report.Id) return NotFound();
            if (!ModelState.IsValid) return View(report);
            await _repo.UpdateAsync(report);
            return RedirectToAction(nameof(Index));
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var report = await _repo.GetByIdAsync(id.Value);
            return report == null ? NotFound() : View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
