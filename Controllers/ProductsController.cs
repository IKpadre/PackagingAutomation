using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PackagingAutomation.Data;
using PackagingAutomation.Models.Entities;

namespace PackagingAutomation.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products
                .Include(p => p.Flavor)
                .Include(p => p.ProductType)
                .Include(p => p.Trademark)
                .Include(p => p.Weight);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Flavor)
                .Include(p => p.ProductType)
                .Include(p => p.Trademark)
                .Include(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["FlavorId"] = new SelectList(Enumerable.Empty<SelectListItem>());
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            ViewData["TrademarkId"] = new SelectList(_context.Trademarks, "Id", "Name");
            ViewData["WeightId"] = new SelectList(_context.Weights, "Id", "Grams");
            return View();
        }

        [HttpGet]
        public JsonResult GetFlavors(int productTypeId)
        {
            var flavors = _context.Flavors
                .Where(f => f.ProductTypeId == productTypeId)
                .Select(f => new { f.Id, f.Name })
                .ToList();

            return Json(flavors);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrademarkId,ProductTypeId,FlavorId,WeightId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlavorId"] = new SelectList(_context.Flavors, "Id", "Name", product.FlavorId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewData["TrademarkId"] = new SelectList(_context.Trademarks, "Id", "Name", product.TrademarkId);
            ViewData["WeightId"] = new SelectList(_context.Weights, "Id", "Grams", product.WeightId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["FlavorId"] = new SelectList(Enumerable.Empty<SelectListItem>());
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewData["TrademarkId"] = new SelectList(_context.Trademarks, "Id", "Name", product.TrademarkId);
            ViewData["WeightId"] = new SelectList(_context.Weights, "Id", "Grams", product.WeightId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrademarkId,ProductTypeId,FlavorId,WeightId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlavorId"] = new SelectList(_context.Flavors, "Id", "Name", product.FlavorId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            ViewData["TrademarkId"] = new SelectList(_context.Trademarks, "Id", "Name", product.TrademarkId);
            ViewData["WeightId"] = new SelectList(_context.Weights, "Id", "Grams", product.WeightId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Flavor)
                .Include(p => p.ProductType)
                .Include(p => p.Trademark)
                .Include(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
