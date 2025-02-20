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
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "Id", "Name");
            ViewData["ProductId"] = new SelectList(_context.Products
                .Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DistributorId,ProductId,Quantity,Deadline,Priority")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "Id", "Name", order.DistributorId);
            ViewData["ProductId"] = new SelectList(_context.Products
                .Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name", order.ProductId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "Id", "Name", order.DistributorId);
            ViewData["ProductId"] = new SelectList(_context.Products.Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name", order.ProductId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DistributorId,ProductId,Quantity,Deadline,Priority")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["DistributorId"] = new SelectList(_context.Distributors, "Id", "Name", order.DistributorId);
            ViewData["ProductId"] = new SelectList(_context.Products.Include(p => p.Trademark)
                .Include(p => p.ProductType)
                .Include(p => p.Flavor)
                .Include(p => p.Weight), "Id", "Name", order.ProductId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Distributor)
                .Include(o => o.Product).ThenInclude(p => p.Trademark)
                .Include(o => o.Product).ThenInclude(p => p.ProductType)
                .Include(o => o.Product).ThenInclude(p => p.Flavor)
                .Include(o => o.Product).ThenInclude(p => p.Weight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
