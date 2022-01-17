using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FinalProject.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SearchSupplier()
        {
            return View(new SearchSupplier());
        }


        [HttpPost]
        public async Task<IActionResult> SearchSupplier(SearchSupplier model)
        {
            if (model.Name is null) //if the user didn't enter anything, return all suppliers.
            {
                model.Suppliers = await _context.tblSuppliers.Include(s => s.Orders).ThenInclude(o => o.Product).ToListAsync();
            }
            else
            {
                model.Suppliers = await _context.tblSuppliers.Where(s => s.Name.ToLower().Contains(model.Name.ToLower())).
                    Include(s => s.Orders).ThenInclude(o => o.Product).ToListAsync();
            }
            return View(model);
        }

        public IActionResult SupplierReport()
        {
            return View(new SupplierReport());
        }
        [HttpPost]
        public async Task<IActionResult> SupplierReport(SupplierReport model)
        {
            if (model.Name is null)
            {
                model.Suppliers = await _context.tblSuppliers.
                    Include(s => s.Orders).
                    ThenInclude(o => o.Product).ToListAsync();
            }
            else
            {
                model.Suppliers = await _context.tblSuppliers.Where(p => p.Name.ToLower().Contains(model.Name.ToLower())).
                    Include(s => s.Orders).
                    ThenInclude(o => o.Product).ToListAsync();
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
