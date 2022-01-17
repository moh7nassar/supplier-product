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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FinalProject.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironement;

        public ProductsController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironement = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string SortBy)
        {
            if (SortBy is null) SortBy = string.Empty;

            switch (SortBy.ToLower())
            {
                case "title_asc":
                    return View(await _context.tblProducts.OrderBy(p => p.Title).ToListAsync());

                case "title_desc":
                    return View(await _context.tblProducts.OrderByDescending(p => p.Title).ToListAsync());

                case "price_asc":
                    return View(await _context.tblProducts.OrderBy(p => p.Price).ToListAsync());
                     
                case "price_desc":
                    return View(await _context.tblProducts.OrderByDescending(p => p.Price).ToListAsync());

                default:
                    return View(await _context.tblProducts.ToListAsync());
            }
            return View(await _context.tblProducts.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.tblProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Title,Price,Photo")] Product product, IFormFile Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo is not null)
                {
                    var GI = Guid.NewGuid().ToString();
                    var FullImageName = $"{_webHostEnvironement.WebRootPath}\\images\\{GI}_{Path.GetFileName(Photo.FileName)}";
                    using (var stream = new FileStream(FullImageName, FileMode.Create)) //Either Create, Open, etc..
                    {
                        Photo.CopyTo(stream);
                        string relativeImagePath = $"/images/{GI}_{Path.GetFileName(Photo.FileName)}";
                        product.Photo = relativeImagePath;
                    }
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.tblProducts.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Title,Price,Photo")] Product product)
        {
            if (id != product.ProductId)
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
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.tblProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
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
            var product = await _context.tblProducts.FindAsync(id);
            _context.tblProducts.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.tblProducts.Any(e => e.ProductId == id);
        }
    }
}
