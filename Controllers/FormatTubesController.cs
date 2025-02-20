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
    public class FormatTubesController : Controller
    {
        private readonly AppDbContext _context;

        public FormatTubesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FormatTubes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormatTubes.ToListAsync());
        }

        // GET: FormatTubes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatTube = await _context.FormatTubes
                .Include(t => t.Weights)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formatTube == null)
            {
                return NotFound();
            }

            return View(formatTube);
        }

        // GET: FormatTubes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormatTubes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FormatTube formatTube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formatTube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formatTube);
        }

        // GET: FormatTubes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatTube = await _context.FormatTubes.FindAsync(id);
            if (formatTube == null)
            {
                return NotFound();
            }
            return View(formatTube);
        }

        // POST: FormatTubes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FormatTube formatTube)
        {
            if (id != formatTube.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formatTube);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormatTubeExists(formatTube.Id))
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
            return View(formatTube);
        }

        // GET: FormatTubes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatTube = await _context.FormatTubes
                .Include(t => t.Weights)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formatTube == null)
            {
                return NotFound();
            }

            return View(formatTube);
        }

        // POST: FormatTubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formatTube = await _context.FormatTubes.FindAsync(id);
            if (formatTube != null)
            {
                _context.FormatTubes.Remove(formatTube);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormatTubeExists(int id)
        {
            return _context.FormatTubes.Any(e => e.Id == id);
        }
    }
}
