using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PackagingAutomation.Data;
using PackagingAutomation.Models.Entities;
using PackagingAutomation.Utilities;

namespace PackagingAutomation.Controllers
{
    public class PackagingMachinesController : Controller
    {
        private readonly AppDbContext _context;

        public PackagingMachinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PackagingMachines
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PackagingMachines
                .Include(p => p.ProductionLine)
                .Include(p => p.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Product).ThenInclude(p => p.Weight);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PackagingMachines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagingMachine = await _context.PackagingMachines
                .Include(p => p.ProductionLine)
                .Include(p => p.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Product).ThenInclude(p => p.Weight)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Distributor)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packagingMachine == null)
            {
                return NotFound();
            }

            return View(packagingMachine);
        }

        // GET: PackagingMachines/Create
        public IActionResult Create()
        {
            ViewData["MachineStatus"] = EnumHelper.GetEnumSelectList<MachineStatus>();
            ViewData["ProductionLineId"] = new SelectList(_context.ProductionLines, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products
                .Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name", null);
            return View();
        }

        // POST: PackagingMachines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductionLineId,Status,ProductId")] PackagingMachine packagingMachine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packagingMachine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineStatus"] = EnumHelper.GetEnumSelectList<MachineStatus>();
            ViewData["ProductionLineId"] = new SelectList(_context.ProductionLines, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products
                .Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name", packagingMachine.ProductId);
            return View(packagingMachine);
        }

        // GET: PackagingMachines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagingMachine = await _context.PackagingMachines.FindAsync(id);
            if (packagingMachine == null)
            {
                return NotFound();
            }
            ViewData["MachineStatus"] = EnumHelper.GetEnumSelectList<MachineStatus>();
            ViewData["ProductionLineId"] = new SelectList(_context.ProductionLines, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products
                .Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name", packagingMachine.ProductId);
            return View(packagingMachine);
        }

        // POST: PackagingMachines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductionLineId,Status,ProductId")] PackagingMachine packagingMachine)
        {
            if (id != packagingMachine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packagingMachine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackagingMachineExists(packagingMachine.Id))
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
            ViewData["MachineStatus"] = EnumHelper.GetEnumSelectList<MachineStatus>();
            ViewData["ProductionLineId"] = new SelectList(_context.ProductionLines, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products
                .Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name", packagingMachine.ProductId);
            return View(packagingMachine);
        }

        // GET: PackagingMachines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packagingMachine = await _context.PackagingMachines
                .Include(p => p.ProductionLine)
                .Include(p => p.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Product).ThenInclude(p => p.Weight)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Distributor)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Schedules).ThenInclude(s => s.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (packagingMachine == null)
            {
                return NotFound();
            }

            return View(packagingMachine);
        }

        // POST: PackagingMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packagingMachine = await _context.PackagingMachines.FindAsync(id);
            if (packagingMachine != null)
            {
                _context.PackagingMachines.Remove(packagingMachine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackagingMachineExists(int id)
        {
            return _context.PackagingMachines.Any(e => e.Id == id);
        }
    }
}
