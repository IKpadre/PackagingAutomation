using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackagingAutomation.Data;
using PackagingAutomation.Models;
using PackagingAutomation.Models.Entities;
using PackagingAutomation.Services;
using PackagingAutomation.Utilities;
using System;
using System.Diagnostics;

namespace PackagingAutomation.Controllers
{
    public class PackagingAutomationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PackagingAutomationController> _logger;

        public PackagingAutomationController(AppDbContext context, ILogger<PackagingAutomationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Orders()
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

            var appDbContext = _context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight)
                .OrderBy(o => o.Priority);

            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Machines()
        {
            var appDbContext = _context.PackagingMachines
                .Include(p => p.ProductionLine)
                .Include(p => p.Product).ThenInclude(p => p.Trademark)
                .Include(p => p.Product).ThenInclude(p => p.ProductType)
                .Include(p => p.Product).ThenInclude(p => p.Flavor)
                .Include(p => p.Product).ThenInclude(p => p.Weight);

            ViewData["MachineStatus"] = EnumHelper.GetEnumSelectList<MachineStatus>();

            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Schedules()
        {
            var orders = await _context.Orders
                .Include(o => o.Distributor)
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

        [HttpPost]
        public async Task<IActionResult> EditStatus(List<PackagingMachine> Machines)
        {
            foreach (var machine in Machines)
            {
                var data = await _context.PackagingMachines.FindAsync(machine.Id);

                if (data != null && data.Status != machine.Status)
                {
                    data.Status = machine.Status;
                    _context.Update(data);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToAction("Machines");
        }
    }
}
