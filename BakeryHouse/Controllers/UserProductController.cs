using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BakeryHouse.Data;
using BakeryHouse.Models;
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
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            TaartViewModel viewModel = new TaartViewModel();
            viewModel.Taarten = await _context.Producten.Where(p=>p.Type=="Taart").Include(p => p.Productregels).ThenInclude(x => x.Ingredient).ToListAsync();
            viewModel.productregels = await _context.Productregels.ToListAsync();
            return View(viewModel);
        }


        public async Task<IActionResult> CupCake()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            TaartViewModel viewModel = new TaartViewModel();
            viewModel.Cupcakes = await _context.Producten.Where(p => p.Type == "Cupcake").Include(p => p.Productregels).ThenInclude(x => x.Ingredient).ToListAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Cake()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            TaartViewModel viewModel = new TaartViewModel();
            viewModel.Cakes = await _context.Producten.Where(p => p.Type == "Cake").Include(p => p.Productregels).ThenInclude(x => x.Ingredient).ToListAsync();
            return View(viewModel);
        }
        public async Task<IActionResult> Brownie()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            TaartViewModel viewModel = new TaartViewModel();
            viewModel.Brownies = await _context.Producten.Where(p => p.Type == "Brownie").Include(p => p.Productregels).ThenInclude(x => x.Ingredient).ToListAsync();
            return View(viewModel);
        }
    }
}
