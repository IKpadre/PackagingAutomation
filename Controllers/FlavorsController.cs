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
    public class FlavorsController : Controller
    {
        private readonly AppDbContext _context;

        public FlavorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Flavors
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Flavors.Include(f => f.ProductType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Flavors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavor = await _context.Flavors
                .Include(f => f.ProductType)
                .Include(f => f.Products).ThenInclude(p => p.Trademark)
                .Include(f => f.Products).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flavor == null)
            {
                return NotFound();
            }

            return View(flavor);
        }

        // GET: Flavors/Create
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            return View();
        }

        // POST: Flavors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductTypeId")] Flavor flavor)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // Логируем ошибки в консоль
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(flavor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", flavor.ProductTypeId);
            return View(flavor);
        }

        // GET: Flavors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavor = await _context.Flavors.FindAsync(id);
            if (flavor == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", flavor.ProductTypeId);
            return View(flavor);
        }

        // POST: Flavors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductTypeId")] Flavor flavor)
        {
            if (id != flavor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flavor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlavorExists(flavor.Id))
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
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", flavor.ProductTypeId);
            return View(flavor);
        }

        // GET: Flavors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavor = await _context.Flavors
                .Include(f => f.ProductType)
                .Include(f => f.Products).ThenInclude(p => p.Trademark)
                .Include(f => f.Products).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flavor == null)
            {
                return NotFound();
            }

            return View(flavor);
        }

        // POST: Flavors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flavor = await _context.Flavors.FindAsync(id);
            if (flavor != null)
            {
                _context.Flavors.Remove(flavor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlavorExists(int id)
        {
            return _context.Flavors.Any(e => e.Id == id);
        }
    }
}
