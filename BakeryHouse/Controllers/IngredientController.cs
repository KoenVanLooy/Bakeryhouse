﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BakeryHouse.Data;
using BakeryHouse.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BakeryHouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IngredientController : Controller
    {
        private readonly BakeryHouseContext _context;

        public IngredientController(BakeryHouseContext context)
        {
            _context = context;
        }

        // GET: Ingredient
        public async Task<IActionResult> Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            return View(await _context.Ingredienten.ToListAsync());
        }

        // GET: Ingredient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredienten
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredient/Create
        public IActionResult Create()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            return View();
        }

        // POST: Ingredient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,Soort,Allergeen,Voorraad,Prijs")] Ingredient ingredient)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredienten.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,Soort,Allergeen,Voorraad,Prijs")] Ingredient ingredient)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id != ingredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientId))
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
            return View(ingredient);
        }

        // GET: Ingredient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredienten
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            var ingredient = await _context.Ingredienten.FindAsync(id);
            _context.Ingredienten.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredienten.Any(e => e.IngredientId == id);
        }
    }
}
