using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackagingAutomation.Data;
using PackagingAutomation.Models;
using PackagingAutomation.Services;
using System;

namespace PackagingAutomation.Controllers
{
    public class PackagingAutomationController : Controller
    {
        private readonly AppDbContext _context;

        public PackagingAutomationController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var nonSetPriorities = _context.Orders.Where(o => o.Priority == 0).OrderDescending();

            if (nonSetPriorities.Any())
            {
                int priority = _context.Orders.Count();

                foreach (var order in nonSetPriorities)
                {
                    order.Priority = (uint)priority--;
                    _context.Update(order);
                }
                
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            var appDbContext = new PackagingAutomationViewModel
            {
                Orders = await _context.Orders
                    .Include(o => o.Distributor)
                    .Include(o => o.Product).ThenInclude(p => p.Trademark)
                    .Include(o => o.Product).ThenInclude(p => p.ProductType)
                    .Include(o => o.Product).ThenInclude(p => p.Flavor)
                    .Include(o => o.Product).ThenInclude(p => p.Weight)
                    .OrderBy(o => o.Priority).ToListAsync(),

                PackagingMachines = await _context.PackagingMachines
                    .Include(p => p.Product).ThenInclude(p => p.Trademark)
                    .Include(p => p.Product).ThenInclude(p => p.ProductType)
                    .Include(p => p.Product).ThenInclude(p => p.Flavor)
                    .Include(p => p.Product).ThenInclude(p => p.Weight)
                    .ToListAsync()
            };

            return View(appDbContext);
        }

        public async Task<IActionResult> ProductionSchedule()
        {
            var orders = await _context.Orders
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight)
                .ToListAsync();
            var packagingMachines = await _context.PackagingMachines
                .Include(p => p.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Product).ThenInclude(p => p.Weight)
                .ToListAsync();
            var appDbContext = SchedulingService.GenerateSchedule(orders, packagingMachines);

            return View(appDbContext.OrderBy(s => s.Machine.Id));
        }

        [HttpPost]
        public async Task<IActionResult> SwapPriority(int id1, int id2)
        {
            var order1 = await _context.Orders.FindAsync(id1);
            var order2 = await _context.Orders.FindAsync(id2);

            if (order1 == null || order2 == null)
            {
                return NotFound();
            }

            (order1.Priority, order2.Priority) = (order2.Priority, order1.Priority);

            _context.Update(order1);
            _context.Update(order2);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
