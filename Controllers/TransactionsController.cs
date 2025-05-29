using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;

namespace ProyectoTestMVC.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _repo;
        public TransactionsController(ITransactionRepository repo)
            => _repo = repo;

        // GET: Transactions
        public async Task<IActionResult> Index()
            => View(await _repo.GetAllAsync());

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var transaction = await _repo.GetByIdAsync(id.Value);
            return transaction == null ? NotFound() : View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create() => View();

        // POST: Transactions/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            if (!ModelState.IsValid) return View(transaction);
            await _repo.AddAsync(transaction);
            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var transaction = await _repo.GetByIdAsync(id.Value);
            return transaction == null ? NotFound() : View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Transaction transaction)
        {
            if (id != transaction.Id) return NotFound();
            if (!ModelState.IsValid) return View(transaction);
            await _repo.UpdateAsync(transaction);
            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var transaction = await _repo.GetByIdAsync(id.Value);
            return transaction == null ? NotFound() : View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
