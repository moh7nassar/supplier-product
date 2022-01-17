using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using FinalProject.Models.ViewModels;

namespace FinalProject.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }
        public IActionResult StatusFiltering(StatusFiltering model)
        {
            IEnumerable<Order> filter;
            filter = _context.tblOrders.Where(o => o.Status == model.Status).Include(o => o.Product).Include(o => o.Supplier).ToList();
            return View("Index", filter);
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.tblOrders.Include(o => o.Product).Include(o => o.Supplier);
            return View(await dataContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.tblOrders
                .Include(o => o.Product)
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.tblProducts, "ProductId", "Title");
            ViewData["SupplierId"] = new SelectList(_context.tblSuppliers, "SupplierId", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,SupplierId,ProductId,OrderDate,Quantity,TotalPrice,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.tblProducts, "ProductId", "Title", order.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.tblSuppliers, "SupplierId", "Name", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.tblOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.tblProducts, "ProductId", "Title", order.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.tblSuppliers, "SupplierId", "Name", order.SupplierId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,SupplierId,ProductId,OrderDate,Quantity,TotalPrice,Status")] Order order)
        {
            if (id != order.OrderId)
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
                    if (!OrderExists(order.OrderId))
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
            ViewData["ProductId"] = new SelectList(_context.tblProducts, "ProductId", "Title", order.ProductId);
            ViewData["SupplierId"] = new SelectList(_context.tblSuppliers, "SupplierId", "Name", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.tblOrders
                .Include(o => o.Product)
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.OrderId == id);
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
            var order = await _context.tblOrders.FindAsync(id);
            _context.tblOrders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.tblOrders.Any(e => e.OrderId == id);
        }
    }
}
