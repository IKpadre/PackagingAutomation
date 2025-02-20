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
    public class WeightsController : Controller
    {
        private readonly AppDbContext _context;

        public WeightsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Weights
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Weights.Include(w => w.FormatTube);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Weights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weight = await _context.Weights
                .Include(w => w.FormatTube)
                .Include(w => w.Products).ThenInclude(p => p.ProductType)
                .Include(w => w.Products).ThenInclude(p => p.Flavor)
                .Include(w => w.Products).ThenInclude(p => p.Trademark)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weight == null)
            {
                return NotFound();
            }

            return View(weight);
        }

        // GET: Weights/Create
        public IActionResult Create()
        {
            ViewData["FormatTubeId"] = new SelectList(_context.FormatTubes, "Id", "Name");
            return View();
        }

        // POST: Weights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grams,Performance,FormatTubeId")] Weight weight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormatTubeId"] = new SelectList(_context.FormatTubes, "Id", "Name", weight.FormatTubeId);
            return View(weight);
        }

        // GET: Weights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weight = await _context.Weights.FindAsync(id);
            if (weight == null)
            {
                return NotFound();
            }
            ViewData["FormatTubeId"] = new SelectList(_context.FormatTubes, "Id", "Name", weight.FormatTubeId);
            return View(weight);
        }

        // POST: Weights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grams,Performance,FormatTubeId")] Weight weight)
        {
            if (id != weight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeightExists(weight.Id))
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
            ViewData["FormatTubeId"] = new SelectList(_context.FormatTubes, "Id", "Name", weight.FormatTubeId);
            return View(weight);
        }

        // GET: Weights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weight = await _context.Weights
                .Include(w => w.FormatTube)
                .Include(w => w.Products).ThenInclude(p => p.ProductType)
                .Include(w => w.Products).ThenInclude(p => p.Flavor)
                .Include(w => w.Products).ThenInclude(p => p.Trademark)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weight == null)
            {
                return NotFound();
            }

            return View(weight);
        }

        // POST: Weights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weight = await _context.Weights.FindAsync(id);
            if (weight != null)
            {
                _context.Weights.Remove(weight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeightExists(int id)
        {
            return _context.Weights.Any(e => e.Id == id);
        }
    }
}
