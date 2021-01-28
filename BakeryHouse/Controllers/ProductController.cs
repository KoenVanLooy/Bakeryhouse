using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BakeryHouse.Data;
using BakeryHouse.Models;
using BakeryHouse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using BakeryHouse.Helper;
using System.Security.Claims;

namespace BakeryHouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly BakeryHouseContext _context;

        public ProductController(BakeryHouseContext context)
        {
            
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(
             string sortOrder,
             string currentFilter,
             string searchString,
             int? pageNumber)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            IndexProductModel viewModel = new IndexProductModel();
            viewModel.CurrentSort = sortOrder;
            viewModel.NaamSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            viewModel.PrijsSortParm = sortOrder == "Prijs" ? "prijs_desc" : "Prijs";
            viewModel.TypeSortParm = sortOrder == "Type" ? "type_desc" : "Type";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            viewModel.CurrentFilter = searchString;

            var producten = from p in _context.Producten
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                producten = producten.Where(p => p.Naam.Contains(searchString)
                                       || p.Type.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    producten = producten.OrderByDescending(p => p.Naam);
                    break;
                case "Prijs":
                    producten = producten.OrderBy(p => p.Prijs);
                    break;
                case "prijs_desc":
                    producten = producten.OrderByDescending(p => p.Prijs);
                    break;
                case "Type":
                    producten = producten.OrderBy(p => p.Type);
                    break;
                case "type_desc":
                    producten = producten.OrderByDescending(p => p.Type);
                    break;
                default:
                    producten = producten.OrderBy(p => p.Naam);
                    break;
            }
            int pageSize = 4;
            viewModel.paginaList = await PaginatedList<Product>.CreateAsync(producten.AsNoTracking(), pageNumber ?? 1, pageSize);
            
            return View(viewModel);
           
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            CreateProductViewModel viewModel = new CreateProductViewModel
            {
                Product = new Product(),
                Ingredientenlijst = new SelectList(_context.Ingredienten, "IngredientId", "Soort"),
                GeselecteerdeIngredienten = new List<int>()
            };

            return View(viewModel);
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);

            if (ModelState.IsValid)
            {
                List<Productregel> nieuweRegels = new List<Productregel>();
                foreach (int IngredientId in viewModel.GeselecteerdeIngredienten)
                {
                    Productregel productregel = new Productregel();
                    productregel.IngredientId = IngredientId;
                    productregel.ProductId = viewModel.Product.ProductId;

                    nieuweRegels.Add(productregel);
                }

                _context.Add(viewModel.Product);
                await _context.SaveChangesAsync();
                Product product = await _context.Producten.Include(p => p.Productregels)
                    .SingleOrDefaultAsync(x => x.ProductId == viewModel.Product.ProductId);
                foreach (Productregel productregel in nieuweRegels)
                {
                    product.Productregels.Add(productregel);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten.Include(p => p.Productregels).
                SingleOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            EditProductViewModel viewModel = new EditProductViewModel
            {
                Product = product,
                Ingredientenlijst = new SelectList(_context.Ingredienten, "IngredientId", "Soort"),
                GeselecteerdeIngredienten = product.Productregels.Select(pr => pr.IngredientId)
            };
            return View(viewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductViewModel viewModel)
        {
            Product product = await _context.Producten.Include(p => p.Productregels).SingleOrDefaultAsync(p => p.ProductId == id);
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id != viewModel.Product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                product.Naam = viewModel.Product.Naam;
                product.Prijs = viewModel.Product.Prijs;
                product.Image = viewModel.Product.Image;
                product.Type = viewModel.Product.Type;

                List<Productregel> productregels = new List<Productregel>();

                foreach (int ingredientid in viewModel.GeselecteerdeIngredienten)
                {
                    productregels.Add(
                    new Productregel
                    {
                        IngredientId = ingredientid,
                        ProductId = viewModel.Product.ProductId    
                    }
                  );
                }
                product.Productregels.RemoveAll(pr => !productregels.Contains(pr));
                product.Productregels.AddRange(productregels.Where(pr => !product.Productregels.Contains(pr)));
               
                _context.Update(product);
                await _context.SaveChangesAsync();
          
                return RedirectToAction(nameof(Index));
            }
            viewModel.Ingredientenlijst = new SelectList(_context.Ingredienten, "IngredientId", "Soort");
            viewModel.GeselecteerdeIngredienten = product.Productregels.Select(pr => pr.IngredientId);
            return View(viewModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.FindAsync(id);
            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.ProductId == id);
        }
    }
}
