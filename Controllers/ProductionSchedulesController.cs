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
    public class ProductionSchedulesController : Controller
    {
        private readonly AppDbContext _context;

        public ProductionSchedulesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProductionSchedules
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProductionSchedules
                .Include(p => p.Machine)
                .Include(p => p.Order).ThenInclude(o => o.Distributor)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Weight);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProductionSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionSchedule = await _context.ProductionSchedules
                .Include(p => p.Machine)
                .Include(p => p.Order).ThenInclude(o => o.Distributor)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productionSchedule == null)
            {
                return NotFound();
            }

            return View(productionSchedule);
        }

        // GET: ProductionSchedules/Create
        public IActionResult Create()
        {
            ViewData["ReconfigType"] = EnumHelper.GetEnumSelectList<ReconfigType>();
            ViewData["MachineId"] = new SelectList(_context.PackagingMachines, "Id", "Name");
            ViewData["OrderId"] = new SelectList(_context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight), "Id", "Name");
            return View();
        }

        // POST: ProductionSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MachineId,OrderId,ReconfigType,StartTime,EndTime")] ProductionSchedule productionSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReconfigType"] = EnumHelper.GetEnumSelectList<ReconfigType>();
            ViewData["MachineId"] = new SelectList(_context.PackagingMachines, "Id", "Name", productionSchedule.MachineId);
            ViewData["OrderId"] = new SelectList(_context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight), "Id", "Name", productionSchedule.OrderId);
            return View(productionSchedule);
        }

        // GET: ProductionSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionSchedule = await _context.ProductionSchedules.FindAsync(id);
            if (productionSchedule == null)
            {
                return NotFound();
            }
            ViewData["ReconfigType"] = EnumHelper.GetEnumSelectList<ReconfigType>();
            ViewData["MachineId"] = new SelectList(_context.PackagingMachines, "Id", "Name", productionSchedule.MachineId);
            ViewData["OrderId"] = new SelectList(_context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight), "Id", "Name", productionSchedule.OrderId);
            return View(productionSchedule);
        }

        // POST: ProductionSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MachineId,OrderId,ReconfigType,StartTime,EndTime")] ProductionSchedule productionSchedule)
        {
            if (id != productionSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionScheduleExists(productionSchedule.Id))
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
            ViewData["ReconfigType"] = EnumHelper.GetEnumSelectList<ReconfigType>();
            ViewData["MachineId"] = new SelectList(_context.PackagingMachines, "Id", "Name", productionSchedule.MachineId);
            ViewData["OrderId"] = new SelectList(_context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight), "Id", "Name", productionSchedule.OrderId);
            return View(productionSchedule);
        }

        // GET: ProductionSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionSchedule = await _context.ProductionSchedules
                .Include(p => p.Machine)
                .Include(p => p.Order).ThenInclude(o => o.Distributor)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Order).ThenInclude(o => o.Product).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productionSchedule == null)
            {
                return NotFound();
            }

            return View(productionSchedule);
        }

        // POST: ProductionSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionSchedule = await _context.ProductionSchedules.FindAsync(id);
            if (productionSchedule != null)
            {
                _context.ProductionSchedules.Remove(productionSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionScheduleExists(int id)
        {
            return _context.ProductionSchedules.Any(e => e.Id == id);
        }
    }
}
