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
    public class UserProductController : Controller
    {
        private readonly BakeryHouseContext _context;
        public UserProductController(BakeryHouseContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            TaartViewModel viewModel = new TaartViewModel();
            viewModel.producten = await _context.Producten.Include(p => p.Productregels).ThenInclude(x => x.Ingredient).ToListAsync();
            viewModel.productregels = await _context.Productregels.ToListAsync();
            return View(viewModel);
        }

      
        public IActionResult CupCake()
        {
            return View();
        }
        public IActionResult Cake()
        {
            return View();
        }
        public IActionResult Brownie()
        {
            return View();
        }
    }
}
