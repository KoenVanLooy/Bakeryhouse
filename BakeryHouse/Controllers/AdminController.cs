using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryHouse.Data;
using BakeryHouse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakeryHouse.Controllers
{
    public class AdminController : Controller
    {
        private readonly BakeryHouseContext _context;

        public AdminController(BakeryHouseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            AdminViewModel viewModel = new AdminViewModel
            {
                Orders = await _context.Orders
                .Include(o => o.Klant)
                .Include(o => o.Afhaalpunt)
                .Include(o => o.Orderlijnen).ThenInclude(ol => ol.Product)
                .ToListAsync()

            };
            return View(viewModel);

        }
    }
}
