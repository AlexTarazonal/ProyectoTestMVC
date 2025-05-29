using Microsoft.AspNetCore.Mvc;
using ProyectoTestMVC.Interfaces;
using ProyectoTestMVC.Models;
using ProyectoTestMVC.ViewModels;

namespace ProyectoTestMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
            => _repo = repo;

        public async Task<IActionResult> Index(string? search, int? categoryId)
        {
            var list = await _repo.GetAllAsync(search, categoryId);
            ViewBag.Categories = await _repo.GetCategoriesAsync();
            ViewBag.Search = search;
            ViewBag.CategoryId = categoryId;
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _repo.GetCategoriesAsync();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _repo.GetCategoriesAsync();
                return View(product);
            }

            await _repo.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            ViewBag.Categories = await _repo.GetCategoriesAsync();
            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _repo.GetCategoriesAsync();
                return View(product);
            }

            await _repo.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
